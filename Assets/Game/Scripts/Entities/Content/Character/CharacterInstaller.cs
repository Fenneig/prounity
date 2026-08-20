using Atomic.Elements;
using Atomic.Entities;
using Game.Entities.Animations;
using Game.UI;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CharacterInstaller : SceneEntityInstaller
    {
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private SceneEntity _weapon;
        [SerializeField] private TriggerEvents _triggerEvents;
        [SerializeField] private Const<AnimationEvents> _animationEvents;
        
        public override void Install(IEntity entity)
        {
            entity.AddCharacterTag();
            
            _transformInstaller.Install(entity);

            entity.AddTrigger(_triggerEvents);

            InstallMovement(entity);
            InstallRotation(entity);
            InstallWeapon(entity);
            InstallHealth(entity);
            InstallAnimationEvents(entity);

            entity.AddBehaviour(new InteractBehaviour());
            InstallInput(entity);
            
            entity.AddScore(new ReactiveVariable<int>(0));
        }

        private void InstallAnimationEvents(IEntity entity)
        {
            entity.AddAnimationEvents(_animationEvents);
            entity.AddBehaviour(new AnimationEventBehaviour());
        }

        private void InstallInput(IEntity entity)
        {
            entity.AddBehaviour(new InputController(GameUI.Instance));
        }

        private void InstallMovement(IEntity entity)
        {
            _moveInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.MoveStep(args.Direction, args.DeltaTime))
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
        }

        private void InstallRotation(IEntity entity)
        {
            _rotateInstaller.Install(entity);
            
            entity.GetRotateCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
        }

        private void InstallWeapon(IEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddWeapon(new Variable<IEntity>(_weapon));
            entity.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(() => _weapon.GetFireCommand().CanInvoke())
                .AddAction(() => _weapon.GetFireCommand().Invoke());
            
            _weapon.GetOwner().Value = entity;
        }

        private void InstallHealth(IEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddTakeDamageAction(new InlineAction<int>(entity.TakeDamage));
        }
    }
}