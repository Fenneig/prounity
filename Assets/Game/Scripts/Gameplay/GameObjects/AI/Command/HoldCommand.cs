using Modules.AI;

namespace Game.Gameplay
{
    public sealed class HoldCommand : BaseCommand
    {
        public class HoldCommandArgs : BaseCommandArgs
        { }     
        
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
            if (_autoCombat.TryFixedTick(AutoCombatType.HoldPosition))
                return;

            CharacterStateMachine.SwitchState<IdleState>();
        }
    }
}