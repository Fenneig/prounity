using System;
using UnityEngine;

namespace Game
{
    public class TargetSensorComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetMask;
        private TriggerComponent _fieldOfView;

        public event Action<Collider2D> OnFoundTarget; 
        public event Action<Collider2D> OnLostTarget;
        public GameObject Target { get; private set; }
        public bool HasTarget => Target != null;

        private void Awake()
        {
            _fieldOfView = GetComponentInChildren<TriggerComponent>();
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
            {
                OnFoundTarget?.Invoke(checkCollider);
                Target = checkCollider.gameObject;
            }
        }

        private void OnExited(Collider2D checkCollider)
        {
            if (IsTarget(checkCollider))
            {
                OnLostTarget?.Invoke(checkCollider);
                Target = null;
            }
        }

        private bool IsTarget(Collider2D checkCollider) => 
            (_targetMask.value & (1 << checkCollider.gameObject.layer)) != 0;
    }
}