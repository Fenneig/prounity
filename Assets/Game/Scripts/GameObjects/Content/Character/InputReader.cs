using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class InputReader : MonoBehaviour
    {
        [SerializeField] private AttackRequestComponent _pushAttackRequest;
        [SerializeField] private AttackRequestComponent _tossAttackRequest;
        private MoveRequestComponent _moveRequestComponent;
        private JumpRequestComponent _jumpRequestComponent;
        private PlayerInput _playerInput;

        public void Disable()
        {
            _playerInput.Disable();
        }
        
        private void Awake()
        {
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _playerInput.Ground.Jump.started += Jump;

            _playerInput.Ground.Toss.started += Toss;
            _playerInput.Ground.Push.started += Push;
        }

        private void OnDisable()
        {
            _playerInput.Ground.Jump.started -= Jump;

            _playerInput.Ground.Toss.started -= Toss;
            _playerInput.Ground.Push.started -= Push;
        }
        
        private void Update() => _moveRequestComponent.Move(_playerInput.Ground.Move.ReadValue<Vector2>());
        private void Push(InputAction.CallbackContext _) => _pushAttackRequest.Attack();
        private void Toss(InputAction.CallbackContext _) => _tossAttackRequest.Attack();
        private void Jump(InputAction.CallbackContext _) => _jumpRequestComponent.Jump();
    }
}