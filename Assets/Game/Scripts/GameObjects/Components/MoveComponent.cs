using UnityEngine;

namespace Game.GameObjects.Components
{
    public abstract class MoveComponent : MonoBehaviour
    {
        public abstract void Move(Vector2 normalizedDirection);
        public abstract void Initialize(float speed);
    }
}