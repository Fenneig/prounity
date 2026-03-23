using UnityEngine;

namespace Game.Movement
{
    public sealed class RigidbodyMoveComponent : IMoveComponent
    {
        private readonly Rigidbody2D _rigidbody;
        private float _speed;
        
        public RigidbodyMoveComponent(Rigidbody2D rigidbody) => 
            _rigidbody = rigidbody;

        public void Move(Vector2 normalizedDirection)
        {
            if (normalizedDirection.sqrMagnitude == 0)
                return;

            Vector2 newPosition = _rigidbody.position + normalizedDirection * (_speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
        }

        public void UpdateSpeed(float speed) =>
            _speed = speed;
    }
}