using UnityEngine;

namespace Game
{
    public class Snake : MonoBehaviour, 
        MoveRequestComponent.IAction, 
        MoveRequestComponent.ICondition
    {
        private PushDamageAttack _pushDamageAttack;
        private TargetSensorComponent _targetSensorComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveRigidbodyComponent _moveComponent;
        private AttackRequestComponent _attackRequestComponent;
        private LookComponent _lookComponent;
        private HealthComponent _healthComponent;
        private AttackCooldownComponent _attackCooldownComponent;
        private ReachSensorComponent _reachSensorComponent;
        private PhysicsComponent _physicsComponent;
        private GroundedComponent _groundedComponent;

        private void Awake()
        {
            _pushDamageAttack = GetComponent<PushDamageAttack>();
            _targetSensorComponent = GetComponent<TargetSensorComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveRigidbodyComponent>();
            _attackRequestComponent = GetComponent<AttackRequestComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _healthComponent = GetComponent<HealthComponent>();
            _attackCooldownComponent = GetComponent<AttackCooldownComponent>();
            _reachSensorComponent = GetComponent<ReachSensorComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(this);
            
            _attackRequestComponent.SetAction(_pushDamageAttack.Attack);
            _attackRequestComponent.SetCondition(() => _healthComponent.IsAlive && !_attackCooldownComponent.IsAttacking && _groundedComponent.IsGrounded);
        }

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
            _lookComponent.Look(direction.x);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => 
            _healthComponent.IsAlive && 
            _targetSensorComponent.HasTarget && 
            !_attackCooldownComponent.IsAttacking && 
            _groundedComponent.IsGrounded;

        private void OnDied() => _physicsComponent.Disable();

        private void Attack() => _attackRequestComponent.Attack();

        private void OnEnable()
        {
            _reachSensorComponent.TargetReached += Attack;
            _healthComponent.OnDied += OnDied;
        }

        private void OnDisable()
        {
            _reachSensorComponent.TargetReached -= Attack;
            _healthComponent.OnDied -= OnDied;
        }
    }
}