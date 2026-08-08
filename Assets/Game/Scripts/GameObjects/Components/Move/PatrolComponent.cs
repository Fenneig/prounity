using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _threshold = 0.01f;
        
        private int _index;
        private List<Vector3> _bakedPoints = new();
        
        public Vector2 NextPointDirection { get; private set; }

        private void Awake()
        {
            foreach (var point in _points) 
                _bakedPoints.Add(point.position);
            
            UpdateDirection();
        }
        
        private void UpdateDirection()
        {
            Vector2 direction = _bakedPoints[_index] - transform.position;
            NextPointDirection = direction.normalized;
        }

        private void FixedUpdate()
        {
            Vector3 toTarget = transform.position - _bakedPoints[_index];
            if (toTarget.sqrMagnitude <= _threshold)
            {
                _index++;
                if (_index > _bakedPoints.Count - 1)
                    _index = 0;
                
                UpdateDirection();
            }
            
            if (Vector2.Dot(toTarget, NextPointDirection) < 0f)
            {
                UpdateDirection();
            }
        }
    }
}