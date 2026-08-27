using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class RotateState : IState
    {
        private readonly Blackboard _blackboard;
        
        private RotateTransformComponent _rotateComponent;
        private GameObject _target;
        
        private ICondition _invokeCondition;
        
        public RotateState(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }

        public void SetCondition(ICondition invokeCondition)
        {
            _invokeCondition = invokeCondition;
        }

        public void Enter()
        {
            _rotateComponent = _blackboard.GetValue(BlackboardAPI.Character).GetComponent<RotateTransformComponent>();
            _target = _blackboard.GetValue(BlackboardAPI.FireTarget);
        }

        public void OnFixedTick()
        {
            if (_invokeCondition != null && !_invokeCondition.Invoke())
                return;

            _rotateComponent.RotateTowards(_target, Time.fixedDeltaTime);
        }
    }
}