using Game.Bullets;
using Game.Ships;
using Game.Ships.Enemies;
using Game.Ships.Player;
using Game.Visual;
using Modules.UI;
using Modules.Utils;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [Header("Scene entities")] 
        [SerializeField] private ShipsWorld _shipsWorld;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private VfxPool _vfxPool;
        [Header("Player setups")]
        [SerializeField] private ShipConfig _playerShipConfig;
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private CameraShaker _cameraShaker;
        [SerializeField] private TransformBounds _playerArea;
        [SerializeField] private Transform _playerContainer;

        private PlayerShip _player;
        
        private void ShowGameOver(AbstractShip _)
        {
            _gameOverView.Show();
            _shipsWorld.StopGame();
        }

        private void SetupPlayer()
        {
            _player = Instantiate(_playerShipConfig.Prefab, _playerStartPosition, _playerContainer).GetComponent<PlayerShip>(); 
            _player.Construct(_playerShipConfig, _bulletPool, _vfxPool, _playerArea);
            _player.GetComponent<PlayerHealthPresenter>().Construct(_healthView);
            _player.GetComponent<PlayerView>().Construct(_healthView, _cameraShaker);
        }

        private void SetupEnemyFactory() => 
            _enemyFactory.Construct(_player, _bulletPool, _vfxPool);

        private void SetupShipsWorld() => 
            _shipsWorld.StartGame();

        private void SetupBulletPool() => 
            _bulletPool.Construct(_vfxPool);

        private void Awake()
        {
            SetupPlayer();
            SetupEnemyFactory();
            SetupShipsWorld();
            SetupBulletPool();
        }

        private void Start()
        {
            _player.OnDead += ShowGameOver;
        }

        private void OnDestroy()
        {
            _player.OnDead -= ShowGameOver;
        }
    }
}