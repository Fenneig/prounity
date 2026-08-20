using Atomic.Elements;
using Atomic.Entities;
using Game.Entities.Animations;
using UnityEngine;

namespace Game.Entities
{
    public sealed class ZombieInstaller : SceneEntityInstaller
    {
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private Const<float> _reachDistance;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private Collider _collider;
        [SerializeField] private SceneEntity _weapon;
        [SerializeField] private Const<AnimationEvents> _animationEvents;
        
        
        public override void Install(IEntity entity)
        {
            InstallMovement(entity);
            InstallRotate(entity);
            InstallHealth(entity);
            InstallWeapon(entity);
            InstallAnimationEvents(entity);
            _transformInstaller.Install(entity);
            entity.AddTarget(new Variable<IEntity>());
        }

        private void InstallWeapon(IEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddWeapon(new Variable<IEntity>(_weapon));
            var entityWeapon = entity.GetWeapon().Value;
            
            entity.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(entity.HasTarget)
                .AddCondition(() => entity.IsReachTarget(_reachDistance))
                .AddCondition(() => entityWeapon.GetFireCommand().CanInvoke())
                .AddAction(() => entityWeapon.GetFireCommand().Invoke());

            entity.AddWantsToFire(new ReactiveVariable<bool>(false));
            entity.AddBehaviour(new ZombieAiAttackBehaviour());
            entity.AddBehaviour(new MeleeAnimBehaviour());
        }

        private void InstallMovement(IEntity entity)
        {
            _moveInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.GetTarget().Value != null && entity.GetTarget().Value.IsHealthExists())
                .AddCondition(_ => !entity.IsReachTarget(_reachDistance))
                .AddCondition(_ => entity.IsHealthExists())
                .AddCondition(_ => !entity.GetWantsToFire().Value)
                .AddAction(args => entity.MoveStep(args.Direction, args.DeltaTime))
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
            
            entity.AddBehaviour(new ZombieAiMoveBehaviour());
        }

        private void InstallRotate(IEntity entity)
        {
            _rotateInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
        }

        private void InstallHealth(IEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddTakeDamageAction(new InlineAction<int>(entity.TakeDamage));
            entity.GetHealth().Subscribe(health =>
            {
                if (health <= 0)
                    _collider.enabled = false;
            });
        }
        
        private void InstallAnimationEvents(IEntity entity)
        {
            entity.AddAnimationEvents(_animationEvents);
            entity.AddBehaviour(new AnimationEventBehaviour());
        }
    }
}