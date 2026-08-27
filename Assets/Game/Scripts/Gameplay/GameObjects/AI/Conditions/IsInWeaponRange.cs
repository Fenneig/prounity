using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class IsInWeaponRange : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        public bool Invoke()  
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(BlackboardAPI.FireTarget, out GameObject target) ||
                character == null ||
                target == null)
            {
                return false;
            }

            _blackboard.TryGetValue(BlackboardAPI.Weapon, out var weapon);

            if (weapon == null)
                return false;

            Vector3 delta = character.transform.position - target.transform.position;

            float range = weapon.Range;

            return delta.sqrMagnitude <= range * range;
        }
    }
}