using UnityEngine;

namespace Game
{
    public sealed class Spider : MonoBehaviour,
        MoveRequestComponent.IAction,
        MoveRequestComponent.ICondition,
        TouchRequestComponent.IAction,
        TouchRequestComponent.ICondition
    {
        [SerializeField] private float _touchDelay;
        private MoveRequestComponent _moveRequestComponent;
        private MoveRigidbodyComponent _moveComponent;
        private PatrolComponent _patrolComponent;
        private FlipComponent _flipComponent;
        private CollisionComponent _collisionComponent;
        private TouchRequestComponent _touchRequestComponent;
        private HealthComponent _healthComponent;
        private GroundedComponent _groundedComponent;
        private DealDamageComponent _dealDamageComponent;
        private ForceComponent _forceComponent;
        
        private float _touchedTime;

        private void Awake()
        {
            _moveRequestComponent = GetComponentInChildren<MoveRequestComponent>();
            _moveComponent = GetComponentInChildren<MoveRigidbodyComponent>();
            _patrolComponent = GetComponentInChildren<PatrolComponent>();
            _flipComponent = GetComponentInChildren<FlipComponent>();
            _collisionComponent = GetComponentInChildren<CollisionComponent>();
            _touchRequestComponent = GetComponentInChildren<TouchRequestComponent>();
            _healthComponent = GetComponentInChildren<HealthComponent>();
            _groundedComponent = GetComponentInChildren<GroundedComponent>();
            _dealDamageComponent = GetComponentInChildren<DealDamageComponent>();
            _forceComponent = GetComponentInChildren<ForceComponent>();
            
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(this);
            
            _touchRequestComponent.SetAction(this);
            _touchRequestComponent.SetCondition(this);
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += OnDied;
            _collisionComponent.OnEntered += TouchRequest;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= OnDied;
            _collisionComponent.OnEntered -= TouchRequest;
        }

        private void OnDied() => GetComponent<Rigidbody2D>().simulated = false;
        
        private void TouchRequest(Collision2D target) => _touchRequestComponent.Touch(target);

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _flipComponent.Flip(-direction.x);
            _moveComponent.Move(direction);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => 
            _healthComponent.IsAlive &&
            _groundedComponent.IsGrounded;

        void TouchRequestComponent.IAction.Invoke(GameObject target)
        {
            if (_dealDamageComponent.TryDealDamage(target))
            {
                _forceComponent.ForceAtTarget(target);
                _touchedTime = Time.time;
            }
        }

        bool TouchRequestComponent.ICondition.Evaluate() => 
            _healthComponent.IsAlive && 
            _groundedComponent.IsGrounded && 
            Time.time - _touchedTime >= _touchDelay;

        private void FixedUpdate() => _moveRequestComponent.Move(_patrolComponent.NextPointDirection);
    }
}