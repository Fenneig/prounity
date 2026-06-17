using UnityEngine;

namespace Game.GameObjects.Components
{
    public sealed class TransformMoveComponent : MoveComponent
    {
        private float _speed;

        public override void Move(Vector2 normalizedDirection)
        {
            Vector3 moveStep = normalizedDirection * _speed * Time.fixedDeltaTime;
            transform.position += moveStep;
        }

        public override void Initialize(float speed) => 
            _speed = speed;
    }
}