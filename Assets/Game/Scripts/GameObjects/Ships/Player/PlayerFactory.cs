using Game.GameObjects.Bullets;
using Game.GameObjects.Components;
using Game.Systems.Player;
using Game.UI.Ship;
using Game.UI.Visual;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private ShipConfig _playerShipConfig;
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Transform _playerContainer;
        [SerializeField] private CameraShaker _cameraShaker;
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
            playerShip.GetComponent<CameraShakerController>().Construct(_cameraShaker);
            return playerShip;
        }
    }
}