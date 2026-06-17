using Game.GameObjects.Components;
using Game.UI.Ship;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public sealed class Ship : MonoBehaviour
    {
        [SerializeField] private ShipVisual _shipVisual;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShipConfig _shipConfig;

        [SerializeField] private WeaponComponent _weaponComponent;
        
        private Vector2 _moveDirection;
        
        public void SetMoveDirection(Vector2 moveDirection) => 
            _moveDirection = moveDirection;

        public void Initialize()
        {
            GetComponent<HealthComponent>().Initialize(_shipConfig);
            _weaponComponent.Initialize(_shipConfig);
            _moveComponent.Initialize(_shipConfig.MoveSpeed);
        }
       
        public void Fire(Vector3 direction) => 
            _weaponComponent.Fire(direction);

        public void Fire() => 
            _weaponComponent.Fire(transform.up);

        private void Awake() => 
            _shipVisual.SetConfig(_shipConfig);

        private void FixedUpdate() => 
            _moveComponent?.Move(_moveDirection);

        private void LateUpdate() => 
            AnimateMovement();

        private void AnimateMovement()
        {
            Vector3 shipAngles = _viewTransform.localEulerAngles;
            shipAngles.x = _shipConfig.VisualConfig.MoveRotationAngle * _moveDirection.y;
            shipAngles.y = _shipConfig.VisualConfig.MoveRotationAngle / 2 * _moveDirection.x * -1f;
            
            Quaternion shipRotation = Quaternion.Euler(shipAngles);
            float t = _shipConfig.MoveSpeed * Time.deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, shipRotation, t);
        }
    }
}