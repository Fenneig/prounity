using System.Collections.Generic;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class TargetZoneInstaller : GameEntityInstaller
    {
        [SerializeField] private List<GameEntity> _occupiedEntities;
        [SerializeField] private TriggerEvents _triggerEvents;
        
        public override void Install(IGameEntity entity)
        {
            entity.AddBehaviour(new TargetZoneBehaviour(_occupiedEntities));
            entity.AddTrigger(_triggerEvents);
        }
    }
}