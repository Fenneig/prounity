using UnityEngine;

namespace Game.GameObjects.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class RigidbodyMoveComponent : MoveComponent
    {
        private Rigidbody2D _rigidbody;
        private float _speed;

        public override float Speed => _speed;

        public override void Initialize(float speed) =>
            _speed = speed;

        protected override void Move()
        {
            if (Direction == Vector2.zero)
                return;

            Vector2 newPosition = _rigidbody.position + Direction * (_speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
        }

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();
    }
}