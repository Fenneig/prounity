using UnityEngine;

namespace Game
{
    public class Platform : MonoBehaviour, MoveRequestComponent.IAction
    {
        private MoveRequestComponent _moveRequestComponent;
        private IMoveComponent _moveComponent;
        private PatrolComponent _patrolComponent;

        private void Awake()
        {
            _moveRequestComponent = GetComponentInChildren<MoveRequestComponent>();
            _moveComponent = GetComponentInChildren<IMoveComponent>();
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