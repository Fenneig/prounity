using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEvents _triggerEvents;
        private IValue<int> _damage;
        private IAction _destroyAction;
        private IVariable<IEntity> _owner;

        public void Init(IEntity entity)
        {
            _owner = entity.GetOwner();
            _triggerEvents = entity.GetTrigger();
            _damage = entity.GetDamage();
            _destroyAction = entity.GetDestroyAction();
            
            _triggerEvents.OnEntered += OnTriggerEnter;
        }

        public void Dispose(IEntity entity)
        {
            _triggerEvents.OnEntered -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider other)
        {
            CombatUseCase.DealDamage(other, _damage.Value, _owner.Value);
            
            _destroyAction?.Invoke();
        }
    }
}