using UnityEngine;

namespace Game.GameObjects.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class RigidbodyMoveComponent : MoveComponent
    {
        private Rigidbody2D _rigidbody;
        private float _speed;

        public override void Move(Vector2 normalizedDirection)
        {
            if (normalizedDirection.sqrMagnitude == 0)
                return;

            Vector2 newPosition = _rigidbody.position + normalizedDirection * (_speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
        }

        public override void Initialize(float speed) =>
            _speed = speed;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();
    }
}