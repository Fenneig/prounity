using System;
using Game.GameObjects.Bullets;
using Game.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        private BulletFactory _bulletFactory;
        private ShipConfig _shipConfig;

        private Timer _fireCooldown;
        private bool _allowToFire;

        public event Action OnFire;
        public event Action OnReload;

        public bool IsReady => _allowToFire && _fireCooldown.IsFinished;

        public void Construct(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void Initialize(ShipConfig shipConfig)
        {
            _shipConfig = shipConfig;
            _fireCooldown = new Timer(_shipConfig.FireCooldown);
        }

        public void AllowFire() => _allowToFire = true;

        public void ProhibitFire() => _allowToFire = false;

        public void Fire(Vector2 direction)
        {
            if (!_allowToFire)
                return;
            
            _bulletFactory.Spawn(_firePoint.position, direction, _shipConfig.BulletConfig, _shipConfig.Team);
            
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