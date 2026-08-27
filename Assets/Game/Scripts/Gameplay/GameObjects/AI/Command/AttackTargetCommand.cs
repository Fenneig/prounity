using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AttackTargetCommand : BaseCommand
    {
        public class AttackTargetCommandArgs : BaseCommandArgs
        {
            public GameObject Target;
        }
        
        [SerializeField] private CombatBehaviour _combatBehaviour;
        
        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (AttackTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.FireTarget, args.Target);
            Blackboard.SetReferenceValue(BlackboardAPI.MoveTarget, args.Target);
        }

        public override void Stop()
        {
            Blackboard.DelValue(BlackboardAPI.FireTarget);
            Blackboard.DelValue(BlackboardAPI.MoveTarget);
        }

        protected override void OnFixedTick()
        {
            _combatBehaviour.FixedTick(AutoCombatType.ChaseTarget);
        }
    }
}