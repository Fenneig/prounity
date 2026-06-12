using UnityEngine;

namespace Game.GameObjects.Ships.Player
{
    public sealed class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerShip _playerShip;
        
        private Vector2 _moveDirection;
        
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _playerShip.Fire();

            _moveDirection.x = Input.GetAxisRaw(HORIZONTAL_AXIS);
            _moveDirection.y = Input.GetAxisRaw(VERTICAL_AXIS);

            _playerShip.SetMoveDirection(_moveDirection.normalized);
        }
    }
}