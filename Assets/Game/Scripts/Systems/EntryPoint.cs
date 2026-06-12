using Game.GameObjects.Ships;
using Game.GameObjects.Ships.Player;
using Game.Systems.Enemies;
using UnityEngine;

namespace Game.Systems
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [Header("Scene entities")] 
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private PlayerFactory _playerFactory;
        [Header("Systems")]
        [SerializeField] private GameCycle _gameCycle;

        private PlayerShip _player;
        
        private void GameOver(AbstractShip playerShip)
        {
            Destroy(playerShip.gameObject);
            _gameCycle.EndGame();
        }

        private void SetupEnemyFactory() => 
            _enemyFactory.Construct(_player.transform);

        private void Awake()
        {
            _player = _playerFactory.Get();
            SetupEnemyFactory();
            
            _player.GetComponent<HealthComponent>().OnDead += GameOver;
        }

        private void Start()
        {
            _gameCycle.StartGame();
        }

        private void OnDestroy()
        {
            _player.GetComponent<HealthComponent>().OnDead -= GameOver;
        }
    }
}