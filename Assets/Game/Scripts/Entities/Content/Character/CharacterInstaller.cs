using Atomic.Elements;
using Game.Entities.Animations;
using Game.UI;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CharacterInstaller : GameEntityInstaller
    {
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private GameEntity _weapon;
        [SerializeField] private TriggerEvents _triggerEvents;
        [SerializeField] private Const<AnimationEvents> _animationEvents;
        
        public override void Install(IGameEntity entity)
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
        }

        private void InstallAnimationEvents(IGameEntity entity)
        {
            entity.AddAnimationEvents(_animationEvents);
            entity.AddBehaviour(new AnimationEventBehaviour());
        }

        private void InstallMovement(IGameEntity entity)
        {
            _moveInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.MoveStep(args.Direction, args.DeltaTime))
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
        }

        private void InstallRotation(IGameEntity entity)
        {
            _rotateInstaller.Install(entity);
            
            entity.GetRotateCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
        }

        private void InstallWeapon(IGameEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddWeapon(new Variable<IGameEntity>(_weapon));
            entity.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(() => _weapon.GetFireCommand().CanInvoke())
                .AddAction(() => _weapon.GetFireCommand().Invoke());
            
            _weapon.GetOwner().Value = entity;
        }

        private void InstallHealth(IGameEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddTakeDamageAction(new CompositeAction<int>(entity.TakeDamage));
            entity.GetTakeDamageAction().Add(amount => GameUI.Instance.GetHealthScreenView().TakeDamage(amount));
        }
    }
}