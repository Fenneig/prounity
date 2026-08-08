using UnityEngine;

namespace Game
{
    public sealed class Monkey : MonoBehaviour,
        TouchRequestComponent.IAction,
        TouchRequestComponent.ICondition,
        JumpComponent.IAction,
        JumpComponent.ICondition
    {
        [SerializeField] private float _jumpDelay;
        private ForceComponent _forceComponent;
        private JumpComponent _jumpComponent;
        private GroundedComponent _groundedComponent;
        private HealthComponent _healthComponent;
        private TargetComponent _targetComponent;
        private LookAtTargetComponent _lookAtTargetComponent;
        private CollisionComponent _collisionComponent;
        private TouchRequestComponent _touchRequestComponent;
        private DealDamageComponent _dealDamageComponent;
        private float _jumpStartTime;

        private void Awake()
        {
            _jumpComponent = GetComponent<JumpComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _healthComponent = GetComponent<HealthComponent>();
            _targetComponent = GetComponent<TargetComponent>();
            _lookAtTargetComponent = GetComponent<LookAtTargetComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _touchRequestComponent = GetComponent<TouchRequestComponent>();
            _dealDamageComponent = GetComponent<DealDamageComponent>();
            _forceComponent = GetComponent<ForceComponent>();

            _jumpComponent.SetAction(this);
            _jumpComponent.SetCondition(this);

            _touchRequestComponent.SetAction(this);
            _touchRequestComponent.SetCondition(this);
        }

        private void OnEnable()
        {
            _groundedComponent.OnGrounded += Shockwave;
            _targetComponent.OnFoundTarget += SetTarget;
            _targetComponent.OnLostTarget += UnsetTarget;
            _collisionComponent.OnEntered += TouchRequest;
        }

        private void OnDisable()
        {
            _groundedComponent.OnGrounded -= Shockwave;
            _targetComponent.OnFoundTarget -= SetTarget;
            _targetComponent.OnLostTarget -= UnsetTarget;
            _collisionComponent.OnEntered -= TouchRequest;
        }

        private void SetTarget(Collider2D target) => _lookAtTargetComponent.SetTarget(target.transform);

        private void UnsetTarget() => _lookAtTargetComponent.UnsetTarget();

        private void TouchRequest(Collision2D target) => _touchRequestComponent.Touch(target);

        private void Shockwave(bool isLanded)
        {
            if (!isLanded)
                return;

            _forceComponent.ForceAtZone();
            
            _jumpStartTime = Time.time;
        }

        void TouchRequestComponent.IAction.Invoke(GameObject target) => 
            _dealDamageComponent.TryDealDamage(target);

        bool TouchRequestComponent.ICondition.Evaluate() =>
            _healthComponent.IsAlive;

        private void Update() =>
            _jumpComponent.Jump();

        void JumpComponent.IAction.Invoke() => _jumpComponent.Jump();

        bool JumpComponent.ICondition.Evaluate() => _healthComponent.IsAlive &&
                                                    _groundedComponent.IsGrounded &&
                                                    Time.time - _jumpStartTime >= _jumpDelay;
    }
}