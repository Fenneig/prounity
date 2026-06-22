using UnityEngine;

namespace Game.GameObjects.Components
{
    public abstract class MoveComponent : MonoBehaviour
    {
        public Vector2 Direction { set; get; }
        public abstract float Speed { get; }
        public abstract void Initialize(float speed);
        
        protected abstract void Move();

        private void FixedUpdate() => 
            Move();
    }
}