using Game.Gameplay.Core.Attack;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AttackState : IState
    {
        private readonly Blackboard _blackboard;
        
        private AttackComponent _attackComponent;
        private GameObject _target;
        private ICondition _invokeCondition;

        public AttackState(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }

        public void SetCondition(ICondition invokeCondition)
        {
            _invokeCondition = invokeCondition;
        }

        public void Enter()
        {
            _attackComponent = _blackboard.GetValue(BlackboardAPI.Character).GetComponent<AttackComponent>();
            _target = _blackboard.GetValue(BlackboardAPI.FireTarget);
        }

        public void OnFixedTick()
        {
            if (_invokeCondition != null && !_invokeCondition.Invoke())
                return;
            
            if (_attackComponent.CanFire(_target))
                _attackComponent.Attack(_target);
        }
    }
}