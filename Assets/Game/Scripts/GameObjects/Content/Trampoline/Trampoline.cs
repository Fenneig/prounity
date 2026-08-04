using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PushComponent))]
    public sealed class Trampoline : MonoBehaviour
    {
        private TriggerComponent _triggerComponent;
        private PushComponent _pushComponent;

        private void Awake()
        {
            _triggerComponent = GetComponent<TriggerComponent>();
            _pushComponent = GetComponent<PushComponent>();
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
                _pushComponent.Push(target);
        }
    }
}