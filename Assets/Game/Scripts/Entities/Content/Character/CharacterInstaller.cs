using Atomic.Elements;
using Atomic.Entities;
using Game.UI;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CharacterInstaller : SceneEntityInstaller
    {
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private Const<float> _moveSpeed;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private Const<float> _rotateSpeed;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private SceneEntity _weapon;
        [SerializeField] private TriggerEvents _triggerEvents;
        
        
        public override void Install(IEntity entity)
        {
            entity.AddCharacterTag();
            
            _transformInstaller.Install(entity);

            entity.AddTrigger(_triggerEvents);

            InstallMovement(entity);
            InstallRotation(entity);
            InstallWeapon(entity);
            InstallHealth(entity);

            entity.AddBehaviour(new InteractBehaviour());
            InstallInput(entity);
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
            
            entity.AddMoveSpeed(_moveSpeed);
        }

        private void InstallRotation(IEntity entity)
        {
            _rotateInstaller.Install(entity);
            
            entity.GetRotateCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
            
            entity.AddRotationSpeed(_rotateSpeed);
        }

        private void InstallWeapon(IEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddWeapon(new Variable<IEntity>(_weapon));
            var entityWeapon = entity.GetWeapon().Value;
            entity.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(() => entityWeapon.GetFireCommand().CanInvoke())
                .AddAction(() => entityWeapon.GetFireCommand().Invoke());
        }

        private void InstallHealth(IEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddTakeDamageAction(new InlineAction<int>(entity.TakeDamage));
        }
    }
}