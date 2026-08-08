using UnityEngine;

namespace Game
{
    public sealed class Character : MonoBehaviour,
        MoveRequestComponent.IAction,
        MoveRequestComponent.ICondition,
        JumpComponent.IAction,
        JumpComponent.ICondition
    {
        private DualWeaponComponent _dualWeaponComponent;
        private HealthComponent _health;
        
        private MoveRequestComponent _moveRequestComponent;
        private MoveRigidbodyComponent _moveComponent;
        
        private JumpComponent _jumpComponent;
        private GroundedComponent _groundedComponent;
        
        private FlipComponent _flipComponent;

        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveRigidbodyComponent>();
            
            _groundedComponent = GetComponent<GroundedComponent>();
            
            _jumpComponent = GetComponent<JumpComponent>();
                            
            _flipComponent = GetComponent<FlipComponent>();
            _dualWeaponComponent = GetComponent<DualWeaponComponent>();

            _jumpComponent.SetAction(this);
            _jumpComponent.SetCondition(this);
            
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(this);
        }

        private void OnEnable() => _health.OnDied += OnDied;

        private void OnDisable() => _health.OnDied -= OnDied;

        public void Move(Vector2 readValue) => _moveRequestComponent.Move(readValue);

        public void Jump() => _jumpComponent.Jump();

        public void Push() => _dualWeaponComponent.Push();

        public void Toss() => _dualWeaponComponent.Toss();

        private void OnDied() => GetComponent<Rigidbody2D>().simulated = false;

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _flipComponent.Flip(direction.x);
            _moveComponent.Move(direction);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => _health.IsAlive;

        void JumpComponent.IAction.Invoke() => _jumpComponent.Jump();
        
        bool JumpComponent.ICondition.Evaluate() => _groundedComponent.IsGrounded && _health.IsAlive;
    }
}