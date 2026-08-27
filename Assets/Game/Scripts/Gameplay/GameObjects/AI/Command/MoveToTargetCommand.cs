using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveToTargetCommand : BaseCommand
    {
        public class MoveToTargetCommandArgs : BaseCommandArgs
        {
            public GameObject Target;
        }
        
        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (MoveToTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.MoveTarget, args.Target);
            
            CharacterStateMachine.SwitchState<MoveToTargetState>();
        }
        
        public override void Stop()
        {
            Blackboard.DelValue(BlackboardAPI.MoveTarget);
        }
    }
}