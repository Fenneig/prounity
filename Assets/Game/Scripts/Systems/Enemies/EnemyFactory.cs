using System;
using Game.GameObjects.Bullets;
using Game.GameObjects.Ships;
using Game.GameObjects.Ships.Enemies;
using Game.UI.Ship;
using Game.UI.Visual;
using UnityEngine;

namespace Game.Systems.Enemies
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Pool _enemyPool;
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private VfxPool _vfxPool;
        [Header("Points")] 
        [SerializeField] private PositionDistributor _spawnPositions;
        [SerializeField] private PositionDistributor _attackPositions;
        [Header("Dependencies")] 
        [SerializeField] private BulletFactory _bulletFactory;
        
        private Transform _playerTransform;
        private int _index = 0;
        
        public void Construct(Transform playerTransform) => 
            _playerTransform = playerTransform;

        public EnemyShip Spawn()
        {
            EnemyShip newShip = _enemyPool.Get().GetComponent<EnemyShip>();
            newShip.Initialize();
            newShip.SetTarget(_playerTransform);
            newShip.GetComponent<ShipVisual>().Construct(_vfxPool);
            newShip.GetComponent<WeaponComponent>().Construct(_bulletFactory);
            
            SetupShip(_spawnPositions.GetNextPosition(), _attackPositions.GetNextPosition(), newShip);

            newShip.GetComponent<HealthComponent>().OnDead += Return;

            return newShip;
        }
        
        private void SetupShip(Vector2 position, Vector2 destination, EnemyShip ship)
        {
            ship.Initialize(position);
            ship.GetComponent<EnemyFireDistanceChecker>().Initialize(destination);
            ship.name = $"Enemy {++_index}";
            ship.gameObject.SetActive(true);
        }

        private void Return(AbstractShip ship)
        {
            if (ship is not EnemyShip enemyShip)
                throw new ArgumentException($"Trying to return ship of type {nameof(EnemyShip)} to pool but was {ship.GetType().Name}.");

            ship.GetComponent<WeaponComponent>().ProhibitFire();
            ship.GetComponent<HealthComponent>().OnDead -= Return;
            _enemyPool.Return(enemyShip.transform);
        }
    }
}