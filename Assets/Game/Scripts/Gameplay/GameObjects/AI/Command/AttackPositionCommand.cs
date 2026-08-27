using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AttackPositionCommand : BaseCommand
    {
        public class AttackPositionCommandArgs : BaseCommandArgs
        {
            public Vector3 TargetPosition;
        }

        private AutoCombatBehaviour _autoCombat;

        private void Awake()
        {
            _autoCombat = Blackboard.GetValue(BlackboardAPI.AutoCombatBehaviour);
        }

        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (AttackPositionCommandArgs)commandArgs;
            Blackboard.SetPrimitiveValue(BlackboardAPI.TargetPosition, args.TargetPosition);
            _autoCombat.StartCombat();
        }

        public override void Stop()
        {
            Blackboard.DelValue(BlackboardAPI.TargetPosition);
            _autoCombat.StopCombat();
        }

        protected override void OnFixedTick()
        {
            if (_autoCombat.TryFixedTick(AutoCombatType.ChaseTarget))
                return;
            
            CharacterStateMachine.SwitchState<MoveState>();
        }
    }
}