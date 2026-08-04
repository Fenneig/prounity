using UnityEngine;

namespace Game
{
    public class Spider : MonoBehaviour,
        MoveRequestComponent.IAction,
        MoveRequestComponent.ICondition,
        TouchRequestComponent.IAction,
        TouchRequestComponent.ICondition
    {
        private MoveRequestComponent _moveRequestComponent;
        private IMoveComponent _moveComponent;
        private PatrolComponent _patrolComponent;
        private LookComponent _lookComponent;
        private CollisionComponent _collisionComponent;
        private TouchRequestComponent _touchRequestComponent;
        private PushTouchDamage _pushTouchDamage;
        private HealthComponent _healthComponent;
        private GroundedComponent _groundedComponent;
        private CooldownComponent _cooldownComponent;
        private PhysicsComponent _physicsComponent;
        
        private void Awake()
        {
            _physicsComponent = GetComponent<PhysicsComponent>();
            _moveRequestComponent = GetComponentInChildren<MoveRequestComponent>();
            _moveComponent = GetComponentInChildren<IMoveComponent>();
            _patrolComponent = GetComponentInChildren<PatrolComponent>();
            _lookComponent = GetComponentInChildren<LookComponent>();
            _collisionComponent = GetComponentInChildren<CollisionComponent>();
            _touchRequestComponent = GetComponentInChildren<TouchRequestComponent>();
            _pushTouchDamage = GetComponentInChildren<PushTouchDamage>();
            _healthComponent = GetComponentInChildren<HealthComponent>();
            _groundedComponent = GetComponentInChildren<GroundedComponent>();
            _cooldownComponent = GetComponentInChildren<CooldownComponent>();
            
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

        private void OnDied() => _physicsComponent.Disable();
        
        private void TouchRequest(Collision2D target) => _touchRequestComponent.Touch(target);

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _lookComponent.Look(-direction.x);
            _moveComponent.Move(direction);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => 
            _healthComponent.IsAlive &&
            _groundedComponent.IsGrounded;

        void TouchRequestComponent.IAction.Invoke(GameObject target)
        {
            if (!target.gameObject.TryGetComponent(out HealthComponent targetHealthComponent))
                return;
            
            _pushTouchDamage.Damage(targetHealthComponent);

            _cooldownComponent.Reset();
        }

        bool TouchRequestComponent.ICondition.Evaluate() => 
            _cooldownComponent.IsExpired && 
            _healthComponent.IsAlive && 
            _groundedComponent.IsGrounded;

        private void FixedUpdate() => _moveRequestComponent.Move(_patrolComponent.NextPointDirection);
    }
}