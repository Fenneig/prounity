using UnityEngine;

namespace Game.Movement
{
    public interface IMoveComponent
    {
        void Move(Vector2 normalizedDirection);
        void UpdateSpeed(float speed);
    }
}