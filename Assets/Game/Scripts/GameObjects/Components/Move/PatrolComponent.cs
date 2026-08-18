using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _threshold = 0.01f;
        
        private MoveRequestComponent _moveRequestComponent;

        private readonly List<Vector3> _bakedPoints = new();
        
        private int _index;
        private Vector2 _nextPointDirection;

        private void Awake()
        {
            foreach (var point in _points) 
                _bakedPoints.Add(point.position);
            
            UpdateDirection();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
        }
        
        private void UpdateDirection()
        {
            Vector2 direction = _bakedPoints[_index] - transform.position;
            _nextPointDirection = direction.normalized;
        }

        private void FixedUpdate()
        {
            Vector2 targetPosition = GetTargetPosition();

            if (ReachedTarget(targetPosition))
                SelectNextPoint();
            else if (PassedTarget(targetPosition))
                UpdateDirection();

            _moveRequestComponent.Move(_nextPointDirection);
        }

        private Vector2 GetTargetPosition() =>
            _bakedPoints[_index] - transform.position;

        private bool ReachedTarget(Vector2 toTarget) =>
            toTarget.sqrMagnitude <= _threshold;

        private bool PassedTarget(Vector2 toTarget) =>
            Vector2.Dot(toTarget, _nextPointDirection) < 0f;

        private void SelectNextPoint()
        {
            _index = (_index + 1) % _bakedPoints.Count;
            UpdateDirection();
        }
    }
}