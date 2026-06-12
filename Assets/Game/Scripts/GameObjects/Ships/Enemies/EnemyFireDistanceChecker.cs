using System;
using UnityEngine;

namespace Game.GameObjects.Ships.Enemies
{
    public sealed class EnemyFireDistanceChecker : MonoBehaviour
    {
        [SerializeField] private float _stoppingDistance = 0.25f;

        private bool _isReachFireDistance;
        private Vector3 _fireDestination;
        private Vector3 _moveDirectionNormalized;
        
        public Action OnReachFireDistance;

        public bool IsReachFireDistance => _isReachFireDistance;

        public void Initialize(Vector2 destination)
        {
            _isReachFireDistance = false;
            _fireDestination = destination;
            _moveDirectionNormalized = (_fireDestination - transform.position).normalized;
        }

        public Vector3 GetMoveDirection()
        { 
            if (_isReachFireDistance)
                return Vector3.zero;
            
            Vector3 position = transform.position;
            Vector3 distance = _fireDestination - position;

            bool isReached = Vector3.Dot(distance, _moveDirectionNormalized) <= _stoppingDistance;
            
            if (isReached)
            {
                _isReachFireDistance = true;
                OnReachFireDistance?.Invoke();
                return Vector3.zero;
            }

            return _moveDirectionNormalized;
        }
    }
}