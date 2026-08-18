using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class InputReader : MonoBehaviour
    {
        [SerializeField] private GameObject _controllableObject;
        private PlayerInput _playerInput;
        
        private MoveRequestComponent _moveRequestComponent;
        private JumpComponent _jumpComponent;
        private IPushComponent _pushComponent;
        private ITossComponent _tossComponent;
        
        private void Awake()
        {
            _playerInput = new PlayerInput();
            _moveRequestComponent = _controllableObject.GetComponent<MoveRequestComponent>();
            _jumpComponent = _controllableObject.GetComponent<JumpComponent>();
            _pushComponent = _controllableObject.GetComponent<IPushComponent>();
            _tossComponent = _controllableObject.GetComponent<ITossComponent>();
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
        
        private void Update()
        {
            Vector2 direction = _playerInput.Ground.Move.ReadValue<Vector2>();
            _moveRequestComponent.Move(direction);
        }
        
        private void Push(InputAction.CallbackContext _) => _pushComponent.Push();
        private void Toss(InputAction.CallbackContext _) => _tossComponent.Toss();
        private void Jump(InputAction.CallbackContext _) => _jumpComponent.Jump();
    }
}