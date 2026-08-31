using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public static class MoveUseCase
    {
        public static void MoveStep(this IGameEntity entity, Vector3 direction, float deltaTime)
        {
            IVariable<Vector3> position = entity.GetPosition();
            position.Value += direction * entity.GetMoveSpeed().Value * deltaTime;
        }

        public static Vector3 GetNormalizedDirectionToTarget(this IGameEntity entity, Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - entity.GetPosition().Value;
            direction.y = 0;
            return direction.normalized;
        }
        
        public static bool IsMoving(this IGameEntity entity) => 
            Time.time - entity.GetMoveTime().Value < entity.GetMoveDuration().Value;
        
    }
}