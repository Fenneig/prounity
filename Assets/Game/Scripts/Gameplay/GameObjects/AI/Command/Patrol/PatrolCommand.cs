using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PatrolCommand : BaseCommand
    {
        [SerializeReference] private ICondition _reachPositionCondition;
        [SerializeReference] private ICondition _reachTargetCondition;

        private ICondition _currentReachCondition;
        
        public class PatrolCommandArgs : BaseCommandArgs
        {
            public IPatrolTarget Target;
        }

        private readonly List<IPatrolTarget> _targets = new();
        private int _index;
        
        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (PatrolCommandArgs)commandArgs;
            
            InitializeTargets(args.Target);
            SetCurrentTarget(args.Target);
        }

        public override EnqueueResult HandleEnqueue(ICommandArgs commandArgs)
        {
            if (commandArgs is PatrolCommandArgs patrolCommandArgs)
            {
                _targets.Add(patrolCommandArgs.Target); 
                return EnqueueResult.Handled;
            }

            return base.HandleEnqueue(commandArgs);
        }
        
        protected override void OnFixedTick()
        {
            if (IsCurrentTargetReached()) 
                MoveToNextPoint();
        }

        private void MoveToNextPoint()
        {
            _index = (_index + 1) % _targets.Count;
            
            Debug.Log($"Go to point {_index}");
            
            SetCurrentTarget(_targets[_index]);
        }

        private void InitializeTargets(IPatrolTarget target)
        {
            _targets.Clear();
            _targets.Add(new PositionPatrolTarget(Blackboard.GetValue(BlackboardAPI.Character).transform.position));
            _targets.Add(target);

            _index = 1;
        }

        private bool IsCurrentTargetReached() => 
            _currentReachCondition?.Invoke() == true;

        private void SetCurrentTarget(IPatrolTarget target)
        {
            ConfigureMovement(target);
            _currentReachCondition = GetReachCondition(target);
            
            if (_targets[_index] is GameObjectPatrolTarget gameObjectPatrolTarget)
            {
                Blackboard.SetReferenceValue(BlackboardAPI.MoveTarget, gameObjectPatrolTarget.Target);
                CharacterStateMachine.SwitchState<MoveToTargetState>();
            }
            else
            {
                Blackboard.SetPrimitiveValue(BlackboardAPI.TargetPosition, target.Position);
                CharacterStateMachine.SwitchState<MoveState>();
            }

            _currentReachCondition = _targets[_index] is PositionPatrolTarget ? _reachPositionCondition : _reachTargetCondition;
        }

        private void ConfigureMovement(IPatrolTarget target)
        {
            if (target is GameObjectPatrolTarget objectTarget)
            {
                MoveToGameObject(objectTarget);
                return;
            }

            MoveToPosition(target);
        }

        private void MoveToGameObject(GameObjectPatrolTarget target)
        {
            Blackboard.SetReferenceValue(BlackboardAPI.MoveTarget, target.Target);

            CharacterStateMachine.SwitchState<MoveToTargetState>();
        }

        private void MoveToPosition(IPatrolTarget target)
        {
            Blackboard.SetPrimitiveValue(BlackboardAPI.TargetPosition, target.Position);

            CharacterStateMachine.SwitchState<MoveState>();
        }

        private ICondition GetReachCondition(IPatrolTarget target) =>
            target is GameObjectPatrolTarget ? _reachTargetCondition : _reachPositionCondition;
    }
}