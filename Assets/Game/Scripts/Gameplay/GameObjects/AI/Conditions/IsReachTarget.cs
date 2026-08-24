using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class IsReachTarget: ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        [SerializeField]
        [BlackboardValueKey(typeof(float))]
        private string _stoppingDistanceKey;
        
        public bool Invoke() =>
            _blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) &&
            _blackboard.TryGetValue(BlackboardAPI.Target, out GameObject target) &&
            Vector3.Distance(character.transform.position, target.transform.position) < _blackboard.GetValue<float>(_stoppingDistanceKey);
    }
}