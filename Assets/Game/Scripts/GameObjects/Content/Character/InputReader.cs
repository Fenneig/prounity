using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class InputReader : MonoBehaviour
    {
        [SerializeField] private Character _character;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
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
            
            _playerInput.Disable();
        }
        
        //private void Update() => _character.Move(_playerInput.Ground.Move.ReadValue<Vector2>());
        private void Update()
        {
            Debug.Assert(_character != null, "_character is null", this);
            Debug.Assert(_playerInput != null, "_playerInput is null", this);
            Debug.Assert(_playerInput.Ground.Move != null, "Move action is null", this);

            Vector2 direction = _playerInput.Ground.Move.ReadValue<Vector2>();
            _character.Move(direction);
        }
        private void Push(InputAction.CallbackContext _) => _character.Push();
        private void Toss(InputAction.CallbackContext _) => _character.Toss();
        private void Jump(InputAction.CallbackContext _) => _character.Jump();
    }
}