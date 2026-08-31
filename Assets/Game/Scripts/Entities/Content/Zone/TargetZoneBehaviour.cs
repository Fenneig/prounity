using System.Collections.Generic;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class TargetZoneBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private TriggerEvents _events;
        private readonly List<IGameEntity> _occupiedEntities;
        
        public TargetZoneBehaviour(List<GameEntity> occupiedEntities)
        {
            _occupiedEntities = new List<IGameEntity>();
            
            foreach (var entity in occupiedEntities) 
                _occupiedEntities.Add(entity);
        }
        
        public void Init(IGameEntity entity)
        {
            _events = entity.GetTrigger();

            _events.OnEntered += OnSetTarget;
            _events.OnExited += OnUnsetTarget;
        }

        public void Dispose(IGameEntity entity)
        {
            _events.OnEntered -= OnSetTarget;
            _events.OnExited -= OnUnsetTarget;
        }

        private void OnSetTarget(Collider other)
        {
            var target = other.GetComponentInParent<IGameEntity>();
            if (target == null)
                return;
            
            foreach (var entity in _occupiedEntities)
            {
                if (entity.IsHealthExists())
                    entity.SetTarget(target);
            }
        }

        private void OnUnsetTarget(Collider other)
        {
            if (other == null)
                return;
            
            var target = other.GetComponentInParent<IGameEntity>();
            if (target == null)
                return;

            foreach (var entity in _occupiedEntities)
                if (entity.IsHealthExists() && entity.IsSameTarget(target))
                    entity.UnsetTarget();
        }
    }
}