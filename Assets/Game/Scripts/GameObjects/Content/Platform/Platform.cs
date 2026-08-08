using UnityEngine;

namespace Game
{
    public sealed class Platform : MonoBehaviour, MoveRequestComponent.IAction
    {
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveComponent;
        private PatrolComponent _patrolComponent;

        private void Awake()
        {
            _moveRequestComponent = GetComponentInChildren<MoveRequestComponent>();
            _moveComponent = GetComponentInChildren<MoveTransformComponent>();
            _patrolComponent = GetComponentInChildren<PatrolComponent>();

            _moveRequestComponent.SetAction(this);
        }

        public void Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
        }

        private void FixedUpdate()
        {
            _moveRequestComponent.Move(_patrolComponent.NextPointDirection);
        }
    }
}