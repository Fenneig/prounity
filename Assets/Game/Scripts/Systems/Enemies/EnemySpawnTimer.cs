using Game.Utils;
using UnityEngine;

namespace Game.Systems.Enemies
{
    public sealed class EnemySpawnTimer : MonoBehaviour
    {
        [SerializeField] private EnemyWorld _enemyWorld;
        [SerializeField] private GameCycle _gameCycle;
        [Header("Spawn Settings")]
        [SerializeField, Range(0, 10f)] private float _minSpawnCooldown;
        [SerializeField, Range(0, 10f)] private float _maxSpawnCooldown;

        private Timer _spawnTime = new();
        private bool _isGameInProgress;
        
        private void SpawnEnemy()
        {
            if (!_isGameInProgress)
                return;
            
            _enemyWorld.Spawn();
            ResetSpawnTimer();
        }
        
        private void ResetSpawnTimer()
        {
            float newValue = Random.Range(_minSpawnCooldown, _maxSpawnCooldown);

            _spawnTime.SetValue(newValue);
            _spawnTime.Reset();
        }

        private void StartSpawn()
        {
            ResetSpawnTimer();
            _isGameInProgress = true;
        }
        
        private void EndSpawn() => 
            _isGameInProgress = false;
        
        private void Awake()
        {
            _spawnTime.OnFinished += SpawnEnemy;
            _gameCycle.OnGameStarted += StartSpawn;
            _gameCycle.OnGameEnded += EndSpawn;
        }

        private void Update()
        {
            if (_isGameInProgress)
                _spawnTime?.Tick(Time.deltaTime);
        }
        
        private void OnDestroy()
        {
            _spawnTime.OnFinished -= SpawnEnemy;
            _gameCycle.OnGameStarted -= StartSpawn;
            _gameCycle.OnGameEnded -= EndSpawn;
        }
        
        private void OnValidate()
        {
            if (_maxSpawnCooldown < _minSpawnCooldown)
                _maxSpawnCooldown = _minSpawnCooldown;
        }
    }
}