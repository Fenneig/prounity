using Game.GameObjects.Bullets;
using Game.GameObjects.Components;
using Game.Systems;
using Game.UI;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private ShipConfig _playerShipConfig;
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Transform _playerContainer;
        [SerializeField] private TransformBounds _playerArea;
        [SerializeField] private VfxPool _vfxPool;
        [SerializeField] private BulletSpawner _bulletSpawner;

        public Ship Get()
        {
            Ship playerShip = Instantiate(_playerShipConfig.Prefab, _playerStartPosition, _playerContainer);
            playerShip.Initialize();
            playerShip.GetComponent<PlayerShipBoundsClamper>().Construct(_playerArea);
            playerShip.GetComponent<ShipVisual>().Construct(_vfxPool);
            playerShip.GetComponent<WeaponComponent>().Construct(_bulletSpawner);
            return playerShip;
        }
    }
}