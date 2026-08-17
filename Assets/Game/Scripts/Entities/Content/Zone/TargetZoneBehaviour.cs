using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class TargetZoneBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEvents _events;
        private readonly List<IEntity> _occupiedEntities;
        
        public TargetZoneBehaviour(List<SceneEntity> occupiedEntities)
        {
            _occupiedEntities = new List<IEntity>();
            
            foreach (var entity in occupiedEntities) 
                _occupiedEntities.Add(entity);
        }
        
        public void Init(IEntity entity)
        {
            _events = entity.GetTrigger();

            _events.OnEntered += OnSetTarget;
            _events.OnExited += OnUnsetTarget;
        }

        public void Dispose(IEntity entity)
        {
            _events.OnEntered -= OnSetTarget;
            _events.OnExited -= OnUnsetTarget;
        }

        private void OnSetTarget(Collider other)
        {
            var target = other.GetComponentInParent<IEntity>();
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
            
            var target = other.GetComponentInParent<IEntity>();
            if (target == null)
                return;

            foreach (var entity in _occupiedEntities)
                if (entity.IsHealthExists() && entity.IsSameTarget(target))
                    entity.UnsetTarget();
        }
    }
}