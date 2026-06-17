using Game.Systems.Player;
using UnityEngine;

namespace Game.UI
{
    public sealed class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerShipProvider _playerShipProvider;
        
        private Vector2 _moveDirection;
        
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        public void Update()
        {
            if (_playerShipProvider.Player == null) 
                return;
            
            if (Input.GetKeyDown(KeyCode.Space))
                _playerShipProvider.Player.Fire();

            _moveDirection.x = Input.GetAxisRaw(HORIZONTAL_AXIS);
            _moveDirection.y = Input.GetAxisRaw(VERTICAL_AXIS);

            _playerShipProvider.Player.SetMoveDirection(_moveDirection.normalized);
        }
    }
}