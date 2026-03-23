using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ships.Enemies
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private Transform _container;

        private readonly Queue<EnemyShip> _pool = new ();
        private int _index;
        
        public EnemyShip Get(Vector2 position, Vector2 direction)
        {
            if (_pool.Count != 0)
            {
                EnemyShip enemy = _pool.Dequeue();
                enemy.Initialize(position, direction);
                enemy.gameObject.SetActive(true);
                return enemy;
            }

            EnemyShip ship = _enemyFactory.Spawn();
            ship.Initialize(position, direction);
            ship.name = $"Enemy {++_index}";
            ship.gameObject.SetActive(true);
            return ship;
        }
        
        public void Return(AbstractShip ship)
         {
            if (ship is not EnemyShip enemyShip)
                throw new ArgumentException($"Trying to return ship of type {nameof(EnemyShip)} to pool but was {ship.GetType().Name}.");

            enemyShip.gameObject.SetActive(false);
            _pool.Enqueue(enemyShip);
        }
    }
}