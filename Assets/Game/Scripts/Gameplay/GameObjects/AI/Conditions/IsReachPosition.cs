using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class IsReachPosition : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        public bool Invoke() =>
            _blackboard.TryGetValue(BlackboardAPI.TargetPosition, out Vector3 targetPosition) &&
            _blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) &&
            (character.transform.position - targetPosition).sqrMagnitude < _blackboard.GetValue(BlackboardAPI.MoveStoppingDistance) * _blackboard.GetValue(BlackboardAPI.MoveStoppingDistance);
    }
}