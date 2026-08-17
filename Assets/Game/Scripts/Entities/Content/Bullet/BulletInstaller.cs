using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private TriggerEvents _triggerEvents;
        [SerializeField] private LifetimeInstaller _lifetimeInstaller;
        [SerializeField] private Const<int> _damage;
        [SerializeField] private Const<float> _moveSpeed;
        
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _lifetimeInstaller.Install(entity);
            
            entity.AddTrigger(_triggerEvents);
            entity.AddDamage(_damage);
            entity.WhenFixedTick(deltaTime => entity.MoveStep(entity.GetRotation().Value * Vector3.forward, deltaTime));
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddDestroyAction(new InlineAction(() => GameContext.Instance.DespawnBullet(entity)));
            entity.AddRespawnAction(new CompositeAction());
            entity.GetRespawnAction().Add(() => entity.GetLifetime().ResetTime());

            entity.AddBehaviour(new BulletCollisionBehaviour());
        }
    }
}