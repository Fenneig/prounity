using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class InteractBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEvents _triggerEvents;
        private IEntity _self;
        
        public void Init(IEntity entity)
        {
            _triggerEvents = entity.GetTrigger();
            _self = entity;

            _triggerEvents.OnEntered += OnInteract;
        }

        public void Dispose(IEntity entity)
        {
            _triggerEvents.OnEntered -= OnInteract;
        }

        private void OnInteract(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity)) 
                _self.InteractWith(entity);
        }
    }
}