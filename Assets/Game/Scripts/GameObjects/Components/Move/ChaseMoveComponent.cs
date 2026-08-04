using UnityEngine;

namespace Game
{
    public class ChaseMoveComponent : MonoBehaviour
    {
        private TargetSensorComponent _targetSensorComponent;
        private MoveRequestComponent _moveRequestComponent;

        private void Awake()
        {
            _targetSensorComponent = GetComponent<TargetSensorComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
        }

        private void FixedUpdate()
        {
            if (_targetSensorComponent.HasTarget)
            {
                var normalizedDirection =
                    (_targetSensorComponent.Target.transform.position - transform.position).normalized;
                _moveRequestComponent.Move(normalizedDirection);
            }
        }
    }
}