using Game.GameObjects.Ships;
using Game.GameObjects.Ships.Enemies;
using UnityEngine;

namespace Game.Systems.Enemies
{
    public sealed class EnemyWorld : MonoBehaviour
    {
        [SerializeField] private EnemyDieMediator _enemyDieMediator;
        [SerializeField] private EnemyFactory _enemyFactory;

        public void SpawnEnemy()
        {
            EnemyShip ship = _enemyFactory.Spawn();
            ship.GetComponent<HealthComponent>().OnDead += CountDead;
        }

        private void CountDead(AbstractShip destroyedShip)
        {
            destroyedShip.GetComponent<HealthComponent>().OnDead -= CountDead;
            _enemyDieMediator.EnemyDied();
        }
    }
}