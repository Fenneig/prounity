using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class IsReachPosition : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        public bool Invoke() =>
            _blackboard.TryGetValue(BlackboardAPI.TargetPosition, out Vector3 targetPosition) &&
            _blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) &&
            Vector3.Distance(character.transform.position, targetPosition) < _blackboard.GetValue(BlackboardAPI.MoveStoppingDistance);
    }
}