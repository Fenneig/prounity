using UnityEngine;

namespace Game
{
    public sealed class Platform : MonoBehaviour, MoveRequestComponent.IAction
    {
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveComponent;

        private void Awake()
        {
            _moveRequestComponent = GetComponentInChildren<MoveRequestComponent>();
            _moveComponent = GetComponentInChildren<MoveTransformComponent>();

            _moveRequestComponent.SetAction(this);
        }

        void MoveRequestComponent.IAction.Invoke(Vector2 direction) => 
            _moveComponent.Move(direction);
    }
}