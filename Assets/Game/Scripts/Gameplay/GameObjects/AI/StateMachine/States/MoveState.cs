using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class MoveState : IState
    {
        private readonly Blackboard _blackboard;
        private MoveComponent _moveComponent;
        private Vector3 _normalizedDirection;
        
        private ICondition _invokeCondition;

        public MoveState(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }

        public void SetCondition(ICondition invokeCondition)
        {
            _invokeCondition = invokeCondition;
        }
        
        public void Enter()
        {
            _moveComponent = _blackboard.GetValue(BlackboardAPI.Character).GetComponent<MoveComponent>();
        }

        public void OnFixedTick()
        {
            if (_invokeCondition != null && !_invokeCondition.Invoke())
                return;
            
            _normalizedDirection = (_blackboard.GetValue(BlackboardAPI.TargetPosition) - _moveComponent.transform.position).normalized;
            _moveComponent.MoveStep(_normalizedDirection, Time.fixedDeltaTime);
        }
    }
}