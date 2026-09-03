using UnityEngine;

namespace Game
{
    public sealed class Snake : MonoBehaviour,
        MoveRequestComponent.IAction,
        MoveRequestComponent.ICondition,
        ForceComponent.ICondition,
        AttackRequestComponent.ICondition,
        AttackRequestComponent.IAction
    {
        private EnemyWeapon _weapon;
        private AttackRequestComponent _attackRequestComponent;
        private ForceComponent _forceComponent;
        private TargetComponent _targetComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveRigidbodyComponent _moveComponent;
        private FlipComponent _flipComponent;
        private HealthComponent _healthComponent;
        private ReachSensorComponent _reachSensorComponent;
        private GroundedComponent _groundedComponent;

        private void Awake()
        {
            _forceComponent = GetComponent<ForceComponent>();
            _weapon = GetComponent<EnemyWeapon>();
            _attackRequestComponent = GetComponent<AttackRequestComponent>();
            _targetComponent = GetComponent<TargetComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveRigidbodyComponent>();
            _flipComponent = GetComponent<FlipComponent>();
            _healthComponent = GetComponent<HealthComponent>();
            _reachSensorComponent = GetComponent<ReachSensorComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();

            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(this);

            _forceComponent.SetCondition(this);

            _attackRequestComponent.SetAction(this);
            _attackRequestComponent.SetCondition(this);
        }
        
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
        
        private void OnDied() => GetComponent<Rigidbody2D>().simulated = false;

        private void Attack() => _attackRequestComponent.Attack();

        bool ForceComponent.ICondition.Evaluate() => _healthComponent.IsAlive &&
                                                     _forceComponent.CanForce &&
                                                     _groundedComponent.IsGrounded;

        bool MoveRequestComponent.ICondition.Evaluate() =>
            _healthComponent.IsAlive &&
            _targetComponent.HasTarget &&
            _weapon.CanAttack &&
            _groundedComponent.IsGrounded;

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
            _flipComponent.Flip(direction.x);
        }

        bool AttackRequestComponent.ICondition.Evaluate() =>
            _healthComponent.IsAlive &&
            _targetComponent.HasTarget &&
            _weapon.CanAttack &&
            _groundedComponent.IsGrounded;

        void AttackRequestComponent.IAction.Invoke() => 
            _weapon.Attack();
    }
}