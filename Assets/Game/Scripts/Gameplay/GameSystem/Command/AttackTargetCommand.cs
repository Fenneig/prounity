using System;
using Game.Gameplay.Core;
using Game.Gameplay.Core.Attack;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackTargetCommand : BaseCommand
    {
        public class AttackTargetCommandArgs : ICommandArgs
        {
            public Type CommandType { get; set; }
            public GameObject Target;
        }
        
        private enum State
        {
            Chase,
            Rotate,
            Attack
        }
        
        [SerializeReference] private ICondition _chaseCondition;
        [SerializeReference] private ICondition _rotateCondition;
        [SerializeReference] private ICondition _inRangeCondition;

        private State _state;

        private GameObject _attacker;
        private GameObject _target;
        private AttackComponent _attackComponent;
        private MoveComponent _moveComponent;

        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (AttackTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.Target, args.Target);
            
            _attacker = Blackboard.GetValue(BlackboardAPI.Character);
            _target = Blackboard.GetValue(BlackboardAPI.Target);
            
            _attackComponent = _attacker.GetComponent<AttackComponent>();
            _moveComponent = _attacker.GetComponent<MoveComponent>();
        }

        protected override void OnFixedTick()
        {
            _state = UpdateState();
            _state = _inRangeCondition.Invoke() ? State.Attack : State.Chase;

            switch (_state)
            {
                case State.Chase:
                    var direction = _target.transform.position - _attacker.transform.position;
                    MoveToTarget(direction.normalized);
                    break;
                case State.Rotate:
                    
                    break;
                case State.Attack:
                    AttackTarget();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private State UpdateState()
        {
            return State.Attack;
        }

        protected override void CommandComplete()
        {
            Blackboard.DelValue(BlackboardAPI.Target);
            base.CommandComplete();
        }

        private void AttackTarget()
        {
            if (_attackComponent.CanFire(_target))
                _attackComponent.Attack(_target);
        }

        private void MoveToTarget(Vector3 normalizedDirection)
        {
            if (_moveComponent.CanMove(normalizedDirection))
                _moveComponent.MoveStep(normalizedDirection, Time.fixedDeltaTime);
        }

        public override string ToString() => 
            $"{base.ToString()}{_attacker.name} attacking {_target.name}";
    }
}