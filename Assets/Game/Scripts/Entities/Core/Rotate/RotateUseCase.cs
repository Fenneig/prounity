using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public static class RotateUseCase
    {
        public static void RotateStep(this IEntity entity, Vector3 direction, float deltaTime)
        {
            var rotation = entity.GetRotation();
            var speed = entity.GetRotationSpeed();
            
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            rotation.Value = Quaternion.RotateTowards(rotation.Value, targetRotation, speed.Value * deltaTime);
        }
    }
}