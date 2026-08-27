using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class CombatBehaviour
    {
        [SerializeField] private CharacterStateMachine _stateMachine;
        [SerializeReference] private ICondition _preferredRangeCondition;
        [SerializeReference] private ICondition _rotateCondition;
        [SerializeReference] private ICondition _inWeaponRangeCondition;

        public bool FixedTick(AutoCombatType type)
        {
            if (type == AutoCombatType.ChaseTarget && ShouldMove())
            {
                _stateMachine.SwitchState<MoveToTargetState>();
                return true;
            }

            if (!_inWeaponRangeCondition.Invoke())
                return false;

            if (!_rotateCondition.Invoke())
            {
                _stateMachine.SwitchState<RotateState>();
                return true;
            }

            _stateMachine.SwitchState<AttackState>();
            return true;
        }

        private bool ShouldMove()
        {
            if (_stateMachine.CurrentState is MoveToTargetState)
                return !_preferredRangeCondition.Invoke();

            return !_inWeaponRangeCondition.Invoke();
        }
    }
}