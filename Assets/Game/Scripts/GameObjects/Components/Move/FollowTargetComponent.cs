using UnityEngine;

namespace Game
{
    public sealed class FollowTargetComponent : MonoBehaviour
    {
        private TargetComponent _targetComponent;
        private MoveRequestComponent _moveRequestComponent;

        private void Awake()
        {
            _targetComponent = GetComponent<TargetComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
        }

        private void FixedUpdate()
        {
            if (_targetComponent.HasTarget)
            {
                var normalizedDirection =
                    (_targetComponent.Target.transform.position - transform.position).normalized;
                _moveRequestComponent.Move(normalizedDirection);
            }
        }
    }
}