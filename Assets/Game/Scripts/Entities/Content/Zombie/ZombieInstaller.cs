using Atomic.Elements;
using Game.Entities.Animations;
using UnityEngine;

namespace Game.Entities
{
    public sealed class ZombieInstaller : GameEntityInstaller
    {
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameEntity _weapon;
        [SerializeField] private Const<AnimationEvents> _animationEvents;
        [SerializeField] private MeleeAiInstaller _meleeAiInstaller;
        
        
        public override void Install(IGameEntity entity)
        {
            entity.AddScorableTag();
            InstallMovement(entity);
            InstallRotate(entity);
            InstallHealth(entity);
            InstallWeapon(entity);
            InstallAnimationEvents(entity);
            
            _meleeAiInstaller.Install(entity);
            _transformInstaller.Install(entity);
            
            entity.AddTarget(new Variable<IGameEntity>());
        }

        private void InstallWeapon(IGameEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddWeapon(new Variable<IGameEntity>(_weapon));
            var weaponEntity = entity.GetWeapon().Value;
            
            weaponEntity.GetOwner().Value = entity;
            
            entity.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(() => weaponEntity.GetFireCommand().CanInvoke())
                .AddAction(() => weaponEntity.GetFireCommand().Invoke());

            entity.AddWantsToFire(new ReactiveVariable<bool>(false));
            entity.AddBehaviour(new MeleeAttackBehaviour());
            entity.AddBehaviour(new MeleeAnimBehaviour());
        }

        private void InstallMovement(IGameEntity entity)
        {
            _moveInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.MoveStep(args.Direction, args.DeltaTime))
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
            
            entity.AddBehaviour(new FollowTargetBehaviour());
        }

        private void InstallRotate(IGameEntity entity)
        {
            _rotateInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
        }

        private void InstallHealth(IGameEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddTakeDamageAction(new CompositeAction<int>(entity.TakeDamage));
            entity.GetHealth().Subscribe(health =>
            {
                if (health <= 0)
                    _collider.enabled = false;
            });
        }
        
        private void InstallAnimationEvents(IGameEntity entity)
        {
            entity.AddAnimationEvents(_animationEvents);
            entity.AddBehaviour(new AnimationEventBehaviour());
        }
    }
}