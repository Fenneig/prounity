using System;
using UnityEngine;

namespace Game
{
    public sealed class ReachSensorComponent : MonoBehaviour
    {
        [SerializeField] private Transform _attackPoint;

        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private float _detectRadius = .2f;

        private TargetComponent _targetComponent;
        
        private readonly Collider2D[] _results = new Collider2D[1];

        public event Action TargetReached;

        private void Awake() => _targetComponent = GetComponent<TargetComponent>();

        private void Update()
        {
            if (!_targetComponent.HasTarget)
                return;
            
            if (ReachTarget())
                TargetReached?.Invoke();
        }
        
        private bool ReachTarget() =>
            Physics2D.OverlapCircleNonAlloc(
                _attackPoint.position,
                _detectRadius,
                _results,
                _enemyMask) > 0;
    }
}