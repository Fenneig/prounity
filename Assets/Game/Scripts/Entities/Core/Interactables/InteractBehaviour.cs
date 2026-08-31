using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public class InteractBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private TriggerEvents _triggerEvents;
        private IGameEntity _self;
        
        public void Init(IGameEntity entity)
        {
            _triggerEvents = entity.GetTrigger();
            _self = entity;

            _triggerEvents.OnEntered += OnInteract;
        }

        public void Dispose(IGameEntity entity)
        {
            _triggerEvents.OnEntered -= OnInteract;
        }

        private void OnInteract(Collider other)
        {
            if (other.TryGetComponent(out IGameEntity entity)) 
                _self.InteractWith(entity);
        }
    }
}