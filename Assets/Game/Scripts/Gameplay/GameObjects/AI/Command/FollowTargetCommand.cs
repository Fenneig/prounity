using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class FollowTargetCommand : BaseCommand
    {
        public class FollowTargetCommandArgs : BaseCommandArgs
        {
            public GameObject Target;
        }
        
        [SerializeReference] private ICondition _followCondition;
        
        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (FollowTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.MoveTarget, args.Target);
            
            CharacterStateMachine.SwitchState<FollowState>(_followCondition);
        }

        public override void Stop()
        {
            Blackboard.DelValue(BlackboardAPI.MoveTarget);
        }
    }
}