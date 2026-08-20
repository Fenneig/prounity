using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public static class MoveUseCase
    {
        public static void MoveStep(this IEntity entity, Vector3 direction, float deltaTime)
        {
            IVariable<Vector3> position = entity.GetPosition();
            position.Value += direction * entity.GetMoveSpeed().Value * deltaTime;
        }

        public static Vector3 GetNormalizedDirectionToTarget(this IEntity entity, Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - entity.GetPosition().Value;
            direction.y = 0;
            return direction.normalized;
        }
        
        public static bool IsMoving(this IEntity entity) => 
            Time.time - entity.GetMoveTime().Value < entity.GetMoveDuration().Value;
        
        public static bool IsReachTarget(this IEntity entity, float range)
        {
            if (entity.GetTarget().Value == null)
                return false;

            var distanceToTarget = (entity.GetPosition().Value - entity.GetTarget().Value.GetPosition().Value).magnitude;
            return distanceToTarget < range;
        }
    }
}