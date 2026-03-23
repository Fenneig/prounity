using Game.Bullets;
using Game.Ships.Player;
using Game.Visual;
using UnityEngine;

namespace Game.Ships.Enemies
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyShip _enemyShipPrefab;
        [SerializeField] private ShipConfig _enemyShipConfig;
        [SerializeField] private Transform _enemiesContainer;

        private PlayerShip _playerShip;
        private BulletPool _bulletPool;
        private VfxPool _vfxPool;
        
        public void Construct(PlayerShip player, BulletPool bulletPool, VfxPool vfxPool)
        {
            _playerShip = player;
            _bulletPool = bulletPool;
            _vfxPool = vfxPool;
        }

        public EnemyShip Spawn()
        {
            EnemyShip newShip = Instantiate(_enemyShipPrefab, Vector3.zero, Quaternion.identity, _enemiesContainer);
            newShip.Construct(_enemyShipConfig, _bulletPool, _vfxPool, _playerShip.transform);
            return newShip;
        }
    }
}