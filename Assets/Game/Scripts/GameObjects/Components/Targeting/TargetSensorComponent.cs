using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TargetComponent))]
    public sealed class TargetSensorComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetMask;
        private TriggerComponent _fieldOfView;
        private TargetComponent _targetComponent;

        private void Awake()
        {
            _fieldOfView = GetComponentInChildren<TriggerComponent>();
            _targetComponent = GetComponent<TargetComponent>();
        }

        private void OnEnable()
        {
            _fieldOfView.OnEntered += OnEntered;
            _fieldOfView.OnExited += OnExited;
        }

        private void OnDisable()
        {
            _fieldOfView.OnEntered -= OnEntered;
            _fieldOfView.OnExited -= OnExited;
        }

        private void OnEntered(Collider2D checkCollider)
        {
            if (IsTarget(checkCollider)) 
                _targetComponent.SetTarget(checkCollider);
        }

        private void OnExited(Collider2D checkCollider)
        {
            if (IsTarget(checkCollider)) 
                _targetComponent.UnsetTarget();
        }

        private bool IsTarget(Collider2D checkCollider) => 
            (_targetMask.value & (1 << checkCollider.gameObject.layer)) != 0;
    }
}