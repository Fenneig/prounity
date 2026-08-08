using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(ForceComponent))]
    public sealed class Trampoline : MonoBehaviour
    {
        private TriggerComponent _triggerComponent;
        private ForceComponent _pushComponent;

        private void Awake()
        {
            _triggerComponent = GetComponent<TriggerComponent>();
            _pushComponent = GetComponent<ForceComponent>();
        }

        private void OnEnable()
        {
            _triggerComponent.OnEntered += OnEntered;
        }

        private void OnDisable()
        {
            _triggerComponent.OnEntered -= OnEntered;
        }

        private void OnEntered(Collider2D other)
        {
            if (other.TryGetComponent(out Rigidbody2D target)) 
                _pushComponent.ForceAtTarget(target);
        }
    }
}