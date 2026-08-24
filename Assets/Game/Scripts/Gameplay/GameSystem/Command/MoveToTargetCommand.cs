using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class MoveToTargetCommand : BaseCommand
    {
        public class MoveToTargetCommandArgs : BaseCommandArgs
        {
            public GameObject Target;
        }
        
        private MoveComponent _moveComponent;

        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (MoveToTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.Target, args.Target);
            
            _moveComponent = Blackboard.GetValue(BlackboardAPI.Character).GetComponent<MoveComponent>();
        }

        protected override void OnFixedTick()
        {
            Vector3 normalizedDirection = 
                (Blackboard.GetValue(BlackboardAPI.Target).transform.position - _moveComponent.transform.position).normalized;

            _moveComponent.MoveStep(normalizedDirection, Time.fixedDeltaTime);
        }

        public override string ToString() =>
            $"{base.ToString()} {_moveComponent.name} moves to target {Blackboard.GetValue(BlackboardAPI.Target).name}";
    }
}