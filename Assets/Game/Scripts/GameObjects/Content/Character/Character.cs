using UnityEngine;

namespace Game
{
    public sealed class Character : MonoBehaviour,
        MoveRequestComponent.IAction,
        MoveRequestComponent.ICondition
    {
        [SerializeField] private PushAttack _pushAttack;
        [SerializeField] private PushAttack _tossAttack;
        
        private HealthComponent _health;
        
        private MoveRequestComponent _moveRequestComponent;
        private IMoveComponent _moveComponent;
        
        private PhysicsComponent _physics;
        private InputReader _inputReader;
        
        private JumpRequestComponent _jumpRequestComponent;
        private JumpComponent _jumpComponent;
        private GroundedComponent _groundedComponent;
        
        private LookComponent _lookComponent;

        private WeaponState _weaponState;
        private AttackRequestComponent _pushAttackRequest;
        private AttackRequestComponent _tossAttackRequest;

        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<IMoveComponent>();
            _physics = GetComponent<PhysicsComponent>();
            
            _inputReader = GetComponent<InputReader>();

            _groundedComponent = GetComponent<GroundedComponent>();
            
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _jumpComponent = GetComponent<JumpComponent>();
                            
            _lookComponent = GetComponent<LookComponent>();

            _weaponState = GetComponent<WeaponState>();
            _pushAttackRequest = _pushAttack.GetComponent<AttackRequestComponent>();
            _tossAttackRequest = _tossAttack.GetComponent<AttackRequestComponent>();

            _jumpRequestComponent.SetAction(Jump);
            _jumpRequestComponent.SetCondition(() => _groundedComponent.IsGrounded && _health.IsAlive);
            
            _pushAttackRequest.SetAction(Push);
            _pushAttackRequest.SetCondition(() => _weaponState.CanAttack && _health.IsAlive);
            _tossAttackRequest.SetAction(Toss);
            _tossAttackRequest.SetCondition(() => _weaponState.CanAttack && _health.IsAlive);
            
            _moveRequestComponent.SetAction(this);
        }

        private void OnEnable()
        {
            _health.OnDied += OnDied;
        }

        private void OnDisable()
        {
            _health.OnDied -= OnDied;
        }

        public void Invoke(Vector2 direction)
        {
            _lookComponent.Look(direction.x);
            _moveComponent.Move(direction);
        }

        public bool Evaluate() => _health.IsAlive;

        private void Jump() => _jumpComponent.Jump();

        private void Push() => _pushAttack.Attack();
        
        private void Toss() => _tossAttack.Attack();

        private void OnDied()
        {
            _inputReader.Disable();
            _physics.Disable();
        }
    }
}