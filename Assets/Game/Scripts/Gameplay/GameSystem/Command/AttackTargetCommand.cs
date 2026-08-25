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
        
        [SerializeReference] private ICondition _preferredRangeCondition;
        [SerializeReference] private ICondition _rotateCondition;
        [SerializeReference] private ICondition _inWeaponRangeCondition;

        private State _state;

        private GameObject _attacker;
        private GameObject _target;
        private AttackComponent _attackComponent;
        private MoveComponent _moveComponent;
        private RotateTransformComponent _rotateComponent;

        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (AttackTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.Target, args.Target);
            
            _attacker = Blackboard.GetValue(BlackboardAPI.Character);
            _target = Blackboard.GetValue(BlackboardAPI.Target);
            
            _attackComponent = _attacker.GetComponent<AttackComponent>();
            _moveComponent = _attacker.GetComponent<MoveComponent>();
            _rotateComponent = _attackComponent.GetComponent<RotateTransformComponent>();

            _state = UpdateState();
        }

        protected override void OnFixedTick()
        {
            _state = UpdateState();
            
            switch (_state)
            {
                case State.Chase:
                    ChaseTarget();
                    break;
                case State.Rotate:
                    RotateToTarget();
                    break;
                case State.Attack:
                    AttackTarget();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ChaseTarget()
        {
            var direction = _target.transform.position - _attacker.transform.position;
            direction.Normalize();  
            
            if (_moveComponent.CanMove(direction))
                _moveComponent.MoveStep(direction, Time.fixedDeltaTime);
        }

        private void RotateToTarget()
        {
            _rotateComponent.RotateTowards(_target, Time.fixedDeltaTime);
        }

        private void AttackTarget()
        {
            if (_attackComponent.CanFire(_target))
                _attackComponent.Attack(_target);
        }

        private State UpdateState()
        {
            if (_state == State.Chase && !_preferredRangeCondition.Invoke())
                return State.Chase;

            if (_state != State.Chase && !_inWeaponRangeCondition.Invoke())
                return State.Chase;

            if (_rotateCondition.Invoke())
                return State.Rotate;

            return State.Attack;
        }

        protected override void CommandComplete()
        {
            Blackboard.DelValue(BlackboardAPI.Target);
            base.CommandComplete();
        }

        public override string ToString() => 
            $"{base.ToString()}{_attacker.name} attacking {_target.name}";
    }
}