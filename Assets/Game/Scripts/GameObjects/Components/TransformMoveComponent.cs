using UnityEngine;

namespace Game.GameObjects.Components
{
    public sealed class TransformMoveComponent : MoveComponent
    {
        private float _speed;

        public override float Speed => _speed;

        public override void Initialize(float speed) => 
            _speed = speed;

        protected override void Move()
        {
            if (Direction == Vector2.zero) 
                return;
            
            Vector3 moveStep = Direction * _speed * Time.fixedDeltaTime;
            transform.position += moveStep;
        }
    }
}