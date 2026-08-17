using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class ZombieInstaller : SceneEntityInstaller
    {
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private Const<float> _moveDistance;
        [SerializeField] private Const<float> _attackRange;
        [SerializeField] private Const<float> _moveSpeed;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private Const<float> _rotateSpeed;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private Collider _collider;
        [SerializeField] private SceneEntity _weapon;
        
        public override void Install(IEntity entity)
        {
            InstallMovement(entity);
            InstallRotate(entity);
            InstallHealth(entity);
            InstallWeapon(entity);
            _transformInstaller.Install(entity);
            entity.AddTarget(new Variable<IEntity>());
        }

        private void InstallWeapon(IEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddWeapon(new Variable<IEntity>(_weapon));
            var entityWeapon = entity.GetWeapon().Value;
            
            entityWeapon.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(entity.HasTarget)
                .AddCondition(() => entityWeapon.GetFireCommand().CanInvoke())
                .AddCondition(() => entity.IsReachTarget(_attackRange))
                .AddAction(() => entityWeapon.GetFireCommand().Invoke());
        }

        private void InstallMovement(IEntity entity)
        {
            _moveInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.GetTarget().Value != null && entity.GetTarget().Value.IsHealthExists())
                .AddCondition(_ => !entity.IsReachTarget(_moveDistance))
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.MoveStep(args.Direction, args.DeltaTime))
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
            
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddBehaviour(new ZombieAiMoveBehaviour());
        }

        private void InstallRotate(IEntity entity)
        {
            _rotateInstaller.Install(entity);
            
            entity.GetMoveCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(args => entity.RotateStep(args.Direction, args.DeltaTime));
            
            entity.AddRotationSpeed(_rotateSpeed);
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
    }
}