using UnityEngine;

namespace Game.GameObjects.Movement
{
    public abstract class MoveComponent : MonoBehaviour
    {
        public abstract void Move(Vector2 normalizedDirection);
        public abstract void UpdateSpeed(float speed);
    }
}