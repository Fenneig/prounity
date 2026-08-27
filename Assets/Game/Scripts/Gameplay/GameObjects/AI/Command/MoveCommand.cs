using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveCommand : BaseCommand
    {
        public class MoveCommandArgs : BaseCommandArgs
        {
            public Vector3 TargetPosition;
        }
        
        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (MoveCommandArgs)commandArgs;
            Blackboard.SetPrimitiveValue(BlackboardAPI.TargetPosition, args.TargetPosition);
            
            CharacterStateMachine.SwitchState<MoveState>();
        }
        
        public override void Stop()
        {
            Blackboard.DelValue(BlackboardAPI.TargetPosition);
        }
    }
}