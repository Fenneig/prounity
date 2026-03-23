using System;
using Game.Bullets;
using Game.Damage;
using Game.Movement;
using Game.Ships.Visual;
using Game.Utils;
using Game.Visual;
using UnityEngine;

namespace Game.Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ShipVisual))]
    public abstract class AbstractShip : MonoBehaviour, IDamageable
    {
        public delegate void HealthChanged(int oldHealth, int newHealth, int maxHealth);
        
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _viewTransform;

        private int _currentHealth;
        private BulletPool _bulletPool;
        private IMoveComponent _moveComponent;
        private ShipConfig _shipConfig;

        protected Vector3 FirePoint => _firePoint.position;
        protected readonly Timer FireCooldown = new();

        public event HealthChanged OnDamaged;
        public event Action<AbstractShip> OnDead;
        public event Action OnFire;

        public TeamType Team => _shipConfig.Team;
        public ShipConfig ShipConfig => _shipConfig;

        public void ApplyDamage(int amount)
        {
            if (amount <= 0)
                return;

            int oldValue = _currentHealth;
            _currentHealth -= amount;
            OnDamaged?.Invoke(oldValue, _currentHealth, _shipConfig.Health);
            
            if (_currentHealth <= 0) 
                OnDead?.Invoke(this);
        }

        protected void Construct(ShipConfig config, BulletPool bulletPool, VfxPool vfxPool)
        {
            _bulletPool = bulletPool;
            _shipConfig = config;
            _currentHealth = config.Health;
            FireCooldown.SetValue(config.FireCooldown);
            _moveComponent = new RigidbodyMoveComponent(GetComponent<Rigidbody2D>());
            _moveComponent.UpdateSpeed(config.MoveSpeed);
            GetComponent<ShipVisual>().Construct(vfxPool);
        }

        protected void Initialize(Vector2 startPoint)
        {
            transform.position = startPoint;
        }
        
        protected void Fire(Vector2 direction)
        {
            _bulletPool.Spawn(_firePoint.position, direction, _shipConfig.BulletConfig, _shipConfig.Team);
            OnFire?.Invoke();
        }
        
        protected abstract Vector3 GetMoveDirection();

        private void Update() => 
            FireCooldown?.Tick(Time.deltaTime);

        private void FixedUpdate() => 
            _moveComponent?.Move(GetMoveDirection());

        protected virtual void LateUpdate() => 
            AnimateMovement();

        private void AnimateMovement()
        {
            Vector3 shipAngles = _viewTransform.localEulerAngles;
            shipAngles.x = _shipConfig.VisualConfig.MoveRotationAngle * GetMoveDirection().y;
            shipAngles.y = _shipConfig.VisualConfig.MoveRotationAngle / 2 * GetMoveDirection().x * -1f;
            
            Quaternion shipRotation = Quaternion.Euler(shipAngles);
            float t = _shipConfig.MoveSpeed * Time.deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, shipRotation, t);
        }
    }
}