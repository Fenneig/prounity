using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class IsReachTarget : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        [SerializeField]
        [BlackboardValueKey(typeof(float))]
        private string _stoppingDistanceKey;
        
        public bool Invoke()
        {
            _blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character);
            _blackboard.TryGetValue(BlackboardAPI.MoveTarget, out GameObject target);
            
            if (character == null || target == null) return false;
            
            float sqrStoppingDistance = _blackboard.GetValue<float>(_stoppingDistanceKey) * _blackboard.GetValue<float>(_stoppingDistanceKey);
            
            return (character.transform.position - target.transform.position).sqrMagnitude < sqrStoppingDistance;
        }
    }
}