using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class IsInPreferredAttackRange : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        [SerializeField]
        [BlackboardValueKey(typeof(float))]
        private string _rangeOffsetKey;

        public bool Invoke()
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(BlackboardAPI.Target, out GameObject target) ||
                character == null ||
                target == null)
            {
                return false;
            }

            _blackboard.TryGetValue(BlackboardAPI.Weapon, out Weapon weapon);
            if (weapon == null)
                return false;

            _blackboard.TryGetValue(_rangeOffsetKey, out float offset);
            
            float preferredRange = weapon.Range - offset;

            return Vector3.SqrMagnitude(character.transform.position - target.transform.position) <= preferredRange * preferredRange;
        }
    }
}