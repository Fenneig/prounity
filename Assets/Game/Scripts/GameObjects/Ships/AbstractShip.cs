using Game.GameObjects.Movement;
using Game.UI.Ship;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    [RequireComponent(typeof(ShipVisual))]
    public abstract class AbstractShip : MonoBehaviour
    {
        [SerializeField] private ShipVisual _shipVisual;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShipConfig _shipConfig;

        [SerializeField] protected WeaponComponent WeaponComponent;
        
        private Vector2 _moveDirection;
        
        public void SetMoveDirection(Vector2 moveDirection) => 
            _moveDirection = moveDirection;

        public void Initialize()
        {
            _shipVisual.SetConfig(_shipConfig);
            
            GetComponent<HealthComponent>().Initialize(_shipConfig);
            GetComponent<WeaponComponent>().Initialize(_shipConfig);
            GetComponent<MoveComponent>().UpdateSpeed(_shipConfig.MoveSpeed);
        }

        public void Initialize(Vector2 startPoint) => 
            transform.position = startPoint;

        private void FixedUpdate() => 
            _moveComponent?.Move(_moveDirection);

        protected virtual void LateUpdate() => 
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