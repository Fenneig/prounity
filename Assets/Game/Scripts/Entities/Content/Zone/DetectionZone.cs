using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    public class DetectionZone : MonoBehaviour
    {
        [SerializeField] private List<GameEntity> _occupiedEntities;

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponentInParent<IGameEntity>();
            if (target == null)
                return;
            
            foreach (var entity in _occupiedEntities) 
                entity.TrySetTarget(target);
        }

        private void OnTriggerExit(Collider other)
        {
            var target = other.GetComponentInParent<IGameEntity>();
            if (target == null)
                return;

            foreach (var entity in _occupiedEntities)
                    entity.TryUnsetTarget(target);
        }
    }
}