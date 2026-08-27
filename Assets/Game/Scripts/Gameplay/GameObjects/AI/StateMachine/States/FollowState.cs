using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class FollowState : IState
    {
        private readonly Blackboard _blackboard;
        
        private MoveComponent _moveComponent;
        private GameObject _target;
        
        private ICondition _invokeCondition;

        public FollowState(Blackboard blackboard)
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
            _target = _blackboard.GetValue(BlackboardAPI.MoveTarget);
        }

        public void OnFixedTick()
        {
            if (_invokeCondition != null && !_invokeCondition.Invoke())
                return;

            Vector3 normalizedDirection = (_target.transform.position - _moveComponent.transform.position).normalized;
                
            _moveComponent.MoveStep(normalizedDirection, Time.fixedDeltaTime);
        }
    }
}