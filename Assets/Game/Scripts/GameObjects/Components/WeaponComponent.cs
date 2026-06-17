using System;
using Game.GameObjects.Bullets;
using Game.GameObjects.Ships;
using Game.Utils;
using UnityEngine;

namespace Game.GameObjects.Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        private BulletSpawner _bulletSpawner;
        private ShipConfig _shipConfig;

        private Timer _fireCooldown;

        public event Action OnFire;
        public event Action OnReload;

        public void Construct(BulletSpawner bulletPool) => 
            _bulletSpawner = bulletPool;

        public void Initialize(ShipConfig shipConfig)
        {
            _shipConfig = shipConfig;
            _fireCooldown = new Timer(_shipConfig.FireCooldown);
        }

        public void Fire(Vector2 direction)
        {
            _bulletSpawner.SpawnBullet(_firePoint.position, direction, _shipConfig.BulletConfig, _shipConfig.Team);
            
            _fireCooldown.Reset();
            OnFire?.Invoke();
        }

        private void Update()
        {
            if (_fireCooldown == null)
                return;
            
            _fireCooldown.Tick(Time.deltaTime);

            if (_fireCooldown.IsFinished)
                OnReload?.Invoke();
        }
    }
}