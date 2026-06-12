using Game.GameObjects.Bullets;
using Game.UI;
using Game.UI.Ship;
using Game.UI.Visual;
using Modules.UI;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private ShipConfig _playerShipConfig;
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Transform _playerContainer;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private CameraShaker _cameraShaker;
        [SerializeField] private TransformBounds _playerArea;
        [SerializeField] private VfxPool _vfxPool;
        [SerializeField] private BulletFactory _bulletFactory;

        public PlayerShip Get()
        {
            PlayerShip playerShip = Instantiate(_playerShipConfig.Prefab, _playerStartPosition, _playerContainer).GetComponent<PlayerShip>();
            playerShip.Initialize();
            playerShip.Construct(_playerArea);
            playerShip.GetComponent<ShipVisual>().Construct(_vfxPool);
            playerShip.GetComponent<WeaponComponent>().Construct(_bulletFactory);
            playerShip.GetComponent<WeaponComponent>().AllowFire();
            playerShip.GetComponent<PlayerView>().Construct(_cameraShaker);
            playerShip.GetComponent<PlayerHealthPresenter>().Construct(_healthView);
            return playerShip;
        }
    }
}