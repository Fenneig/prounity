using Game.GameObjects.Bullets;
using Game.GameObjects.Components;
using Game.Systems;
using Game.UI;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public sealed class EnemyFactory : Factory<EnemyBehaviour>
    {
        [Header("Dependencies")] 
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private VfxPool _vfxPool;
        [SerializeField] private PlayerShipProvider _playerShipProvider;

        protected override void OnCreate(EnemyBehaviour enemy)
        {
            base.OnCreate(enemy);

            enemy.Construct(_playerShipProvider.Player.transform);
            enemy.GetComponent<ShipVisual>().Construct(_vfxPool);
            enemy.GetComponent<WeaponComponent>().Construct(_bulletSpawner);
        }
    }
}