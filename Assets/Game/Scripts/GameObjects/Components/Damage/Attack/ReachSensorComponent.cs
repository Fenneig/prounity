using System;
using UnityEngine;

namespace Game
{
    public class ReachSensorComponent : MonoBehaviour
    {
        [SerializeField] private Transform _attackPoint;

        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private float _detectRadius = .2f;

        private TargetSensorComponent _targetSensorComponent;
        
        private readonly Collider2D[] _results = new Collider2D[1];

        public event Action TargetReached;

        private void Awake()
        {
            _targetSensorComponent = GetComponent<TargetSensorComponent>();
        }

        private void Update()
        {
            if (!_targetSensorComponent.HasTarget)
                return;
            
            if (HasTarget())
                TargetReached?.Invoke();
        }
        
        private bool HasTarget() =>
            Physics2D.OverlapCircleNonAlloc(
                _attackPoint.position,
                _detectRadius,
                _results,
                _enemyMask) > 0;
    }
}