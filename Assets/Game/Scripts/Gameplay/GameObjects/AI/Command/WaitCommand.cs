using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WaitCommand : BaseCommand
    {
        [SerializeReference] private ICondition _reachPositionCondition;
       
        private AutoCombatBehaviour _autoCombat;
        
        private void Awake()
        {
            _autoCombat = Blackboard.GetValue(BlackboardAPI.AutoCombatBehaviour);
        }

        public override void Initialize(ICommandArgs _)
        {
            Blackboard.SetPrimitiveValue(BlackboardAPI.TargetPosition, transform.position);
            _autoCombat.StartCombat();

            CharacterStateMachine.SwitchState<IdleState>();
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

            UpdateWaitState();
        }

        private void UpdateWaitState()
        {
            if (!_reachPositionCondition.Invoke())
                CharacterStateMachine.SwitchState<MoveState>();
            else
                CharacterStateMachine.SwitchState<IdleState>();
        }

        public override EnqueueResult HandleEnqueue(ICommandArgs commandArgs) => EnqueueResult.Replace;
    }
}