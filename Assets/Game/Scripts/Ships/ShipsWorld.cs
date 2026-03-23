using System;
using Game.Ships.Enemies;
using Game.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Ships
{
    public sealed class ShipsWorld : MonoBehaviour
    {
        [Header("Enemy Settings")]
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField, Range(0, 10f)] private float _minSpawnCooldown;
        [SerializeField, Range(0, 10f)] private float _maxSpawnCooldown;
        [Header("Points")] 
        [SerializeField] private PositionDistributor _spawnPositions;
        [SerializeField] private PositionDistributor _attackPositions;

        private Timer _spawnTime = new();
        private bool _isGameInProgress;

        public event Action OnEnemyDied;

        public void StartGame()
        {
            ResetSpawnTimer();
            _isGameInProgress = true;
        }
        
        public void StopGame() =>
            _isGameInProgress = false;
        
        private void Start()
        {
            _spawnTime.OnFinished += SpawnEnemy;
        }

        private void OnDestroy()
        {
            _spawnTime.OnFinished -= SpawnEnemy;
        }

        private void SpawnEnemy()
        {
            if (!_isGameInProgress)
                return;
            
            EnemyShip enemy = _enemyPool.Get(_spawnPositions.GetNextPosition(), _attackPositions.GetNextPosition());

            enemy.OnDead += DespawnEnemy;
            ResetSpawnTimer();
        }

        private void DespawnEnemy(AbstractShip enemyShip)
        {
            enemyShip.OnDead -= DespawnEnemy;
            _enemyPool.Return(enemyShip);
            OnEnemyDied?.Invoke();
        }

        private void ResetSpawnTimer()
        {
            float newValue = Random.Range(_minSpawnCooldown, _maxSpawnCooldown);

            _spawnTime.SetValue(newValue);
            
            _spawnTime.Reset();
        }

        private void Update()
        {
            if (_isGameInProgress)
                _spawnTime?.Tick(Time.deltaTime);
        }
        
        private void OnValidate()
        {
            if (_maxSpawnCooldown < _minSpawnCooldown)
                _maxSpawnCooldown = _minSpawnCooldown;
        }
    }
}