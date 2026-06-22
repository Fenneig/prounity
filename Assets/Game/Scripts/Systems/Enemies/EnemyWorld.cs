using Game.GameObjects.Components;
using Game.GameObjects.Ships;
using Game.UI;
using UnityEngine;

namespace Game.Systems
{
    public class EnemyWorld : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [Header("Points")] 
        [SerializeField] private PositionDistributor _spawnPositions;
        [SerializeField] private PositionDistributor _attackPositions;
        [Header("Score")] 
        [SerializeField] private ScorePresenter _scorePresenter;
        
        private int _index;
        
        public void Spawn()
        {
            EnemyBehaviour enemy = _enemyPool.Get();

            enemy.transform.position = _spawnPositions.GetNextPosition();
            enemy.GetComponent<Ship>().Initialize();
            
            SetupBehaviour(_attackPositions.GetNextPosition(), enemy);

            enemy.GetComponent<HealthComponent>().OnDead += EnemyDied;
        }
        
        private void SetupBehaviour(Vector2 attackPosition, EnemyBehaviour enemyShip)
        {
            enemyShip.Initialize(attackPosition);
            enemyShip.name = $"Enemy {++_index}";
            enemyShip.gameObject.SetActive(true);
        }

        private void EnemyDied(Ship ship)
        {
            ship.GetComponent<HealthComponent>().OnDead -= EnemyDied;
            _scorePresenter.CountScore();
            _enemyPool.Return(ship.GetComponent<EnemyBehaviour>());
        }
    }
}