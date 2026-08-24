using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class MoveCommand : BaseCommand
    {
        public class MoveCommandArgs : BaseCommandArgs
        {
            public Vector3 TargetPosition;
        }
        
        private MoveComponent _moveComponent;
        private Vector3 _targetPosition;
        private Vector3 _normalizedDirection;

        protected override void OnFixedTick()
        {
            _moveComponent.MoveStep(_normalizedDirection, Time.fixedDeltaTime);
        }

        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (MoveCommandArgs)commandArgs;
            Blackboard.SetPrimitiveValue(BlackboardAPI.TargetPosition, args.TargetPosition);
            
            _targetPosition = Blackboard.GetValue(BlackboardAPI.TargetPosition);
            _moveComponent = Blackboard.GetValue(BlackboardAPI.Character).GetComponent<MoveComponent>();
            
            _normalizedDirection = (_targetPosition - _moveComponent.transform.position).normalized;
        }

        public override string ToString() => $"{base.ToString()} {_moveComponent.name} moves to position {_targetPosition}";
    }
}