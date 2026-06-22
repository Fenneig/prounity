using Game.GameObjects.Components;
using Game.Systems;
using UnityEngine;

namespace Game.UI
{
    public sealed class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerShipProvider _playerShipProvider;
        
        private Vector2 _moveDirection;
        private MoveComponent _moveComponent;
        private WeaponComponent _weaponComponent;
        
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        private void Start()
        {
            _moveComponent = _playerShipProvider.Player.GetComponent<MoveComponent>();
            _weaponComponent = _playerShipProvider.Player.GetComponent<WeaponComponent>();
        }

        public void Update()
        {
            if (_playerShipProvider.Player == null) 
                return;
            
            if (Input.GetKeyDown(KeyCode.Space))
                _weaponComponent.Fire(_playerShipProvider.Player.transform.up);

            _moveDirection.x = Input.GetAxisRaw(HORIZONTAL_AXIS);
            _moveDirection.y = Input.GetAxisRaw(VERTICAL_AXIS);

            _moveComponent.Direction = _moveDirection.normalized;
        }
    }
}