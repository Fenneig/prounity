using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class TargetAngleCondition : ICondition
    {
        public enum Comparison
        {
            Less,
            LessOrEqual,
            Equal,
            GreaterOrEqual,
            Greater
        }

        [SerializeField] private Blackboard _blackboard;

        [SerializeField] 
        [BlackboardValueKey(typeof(GameObject))]
        private string _selfKey;
        
        [SerializeField]
        [BlackboardValueKey(typeof(GameObject))]
        private string _targetKey;
        
        [SerializeField] 
        [BlackboardValueKey(typeof(float))]
        private string _angleKey;
        
        [SerializeField] private Comparison _comparison;
        
        public bool Invoke()
        {
            if (!_blackboard.TryGetValue(_selfKey, out GameObject self))
                return false;

            if (!_blackboard.TryGetValue(_targetKey, out GameObject target))
                return false;
            
            if (!_blackboard.TryGetValue(_angleKey, out float checkAngle))
                return false;

            Vector3 directionToTarget = target.transform.position - self.transform.position;

            float angle = Vector3.Angle(self.transform.forward, directionToTarget);
            return Compare(angle, checkAngle);
        }

        private bool Compare(float angle, float checkAngle)
        {
            return _comparison switch
            {
                Comparison.Less => angle < checkAngle,
                Comparison.LessOrEqual => angle <= checkAngle,
                Comparison.Equal => Mathf.Approximately(angle, checkAngle),
                Comparison.GreaterOrEqual => angle >= checkAngle,
                Comparison.Greater => angle > checkAngle,
                _ => false
            };
        }
    }
}