using UnityEngine;

namespace Game
{
    public class Monkey : MonoBehaviour, TouchRequestComponent.ICondition, TouchRequestComponent.IAction
    {
        private JumpComponent _jumpComponent;
        private JumpRequestComponent _jumpRequestComponent;
        private GroundedComponent _groundedComponent;
        private HealthComponent _healthComponent;
        private PushComponent _pushComponent;
        private AreaDetectorComponent _areaDetectorComponent;
        private TargetSensorComponent _targetSensorComponent;
        private TargetTrackerComponent _targetTrackerComponent;
        private CooldownComponent _cooldownComponent;
        private CollisionComponent _collisionComponent;
        private TouchRequestComponent _touchRequestComponent;
        private TouchDamage _touchDamage;

        private void Awake()
        {
            _jumpComponent = GetComponent<JumpComponent>();
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _healthComponent = GetComponent<HealthComponent>();
            _pushComponent = GetComponent<PushComponent>();
            _areaDetectorComponent = GetComponent<AreaDetectorComponent>();
            _targetSensorComponent = GetComponent<TargetSensorComponent>();
            _targetTrackerComponent = GetComponent<TargetTrackerComponent>();
            _cooldownComponent = GetComponent<CooldownComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _touchRequestComponent = GetComponent<TouchRequestComponent>();
            _touchDamage = GetComponent<TouchDamage>();

            _jumpRequestComponent.SetAction(Jump);
            _jumpRequestComponent.SetCondition(CanJump);

            _touchRequestComponent.SetAction(this);
            _touchRequestComponent.SetCondition(this);
        }

        private void OnEnable()
        {
            _groundedComponent.OnGrounded += Shockwave;
            _targetSensorComponent.OnFoundTarget += SetTarget;
            _targetSensorComponent.OnLostTarget += UnsetTarget;
            _collisionComponent.OnEntered += TouchRequest;
        }

        private void OnDisable()
        {
            _groundedComponent.OnGrounded -= Shockwave;
            _targetSensorComponent.OnFoundTarget -= SetTarget;
            _targetSensorComponent.OnLostTarget -= UnsetTarget;
            _collisionComponent.OnEntered -= TouchRequest;
        }
        
        private void SetTarget(Collider2D target) => _targetTrackerComponent.SetTarget(target.transform);

        private void UnsetTarget(Collider2D _) => _targetTrackerComponent.UnsetTarget();
        
        private void TouchRequest(Collision2D target) => _touchRequestComponent.Touch(target);

        private void Shockwave(bool isLanded)
        {
            if (!isLanded)
                return;
            
            var targets = _areaDetectorComponent.Detect();

            foreach (var target in targets)
            {
                if (target.transform.root == transform.root)
                    continue;
                
                Rigidbody2D rb = target.GetComponentInParent<Rigidbody2D>();
                
                if (rb == null)
                    throw new MissingComponentException($"No Rigidbody2D on {target.name}");
                
                _pushComponent.Push(rb);
            }
            
            _cooldownComponent.Reset();
        }


        private void Jump() => _jumpComponent.Jump();
        private bool CanJump() => _healthComponent.IsAlive &&
                                  _groundedComponent.IsGrounded &&
                                  _cooldownComponent.IsExpired;


        void TouchRequestComponent.IAction.Invoke(GameObject target)
        {
            if (!target.gameObject.TryGetComponent(out HealthComponent healthComponent))
                return;
            
            _touchDamage.Damage(healthComponent);
        }

        bool TouchRequestComponent.ICondition.Evaluate() =>
            _healthComponent.IsAlive;

        private void Update() => 
            _jumpRequestComponent.Jump();
    }
}