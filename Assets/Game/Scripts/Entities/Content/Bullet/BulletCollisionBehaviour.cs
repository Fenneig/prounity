using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class BulletCollisionBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private TriggerEvents _triggerEvents;
        private IValue<int> _damage;
        private IAction _destroyAction;
        private IVariable<IGameEntity> _owner;

        public void Init(IGameEntity entity)
        {
            _owner = entity.GetOwner();
            _triggerEvents = entity.GetTrigger();
            _damage = entity.GetDamage();
            _destroyAction = entity.GetDestroyAction();
            
            _triggerEvents.OnEntered += OnTriggerEnter;
        }

        public void Dispose(IGameEntity entity)
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