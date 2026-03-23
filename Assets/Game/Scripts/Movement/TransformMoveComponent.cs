using UnityEngine;

namespace Game.Movement
{
    public sealed class TransformMoveComponent : IMoveComponent
    {
        private readonly Transform _transform;
        private float _speed;

        public TransformMoveComponent(Transform transform) => 
            _transform = transform;

        public void Move(Vector2 normalizedDirection)
        {
            Vector3 moveStep = normalizedDirection * _speed * Time.fixedDeltaTime;
            _transform.position += moveStep;
        }

        public void UpdateSpeed(float speed) => 
            _speed = speed;
    }
}