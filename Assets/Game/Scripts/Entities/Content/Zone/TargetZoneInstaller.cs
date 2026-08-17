using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class TargetZoneInstaller : SceneEntityInstaller
    {
        [SerializeField] private List<SceneEntity> _occupiedEntities;
        [SerializeField] private TriggerEvents _triggerEvents;
        
        public override void Install(IEntity entity)
        {
            entity.AddBehaviour(new TargetZoneBehaviour(_occupiedEntities));
            entity.AddTrigger(_triggerEvents);
        }
    }
}