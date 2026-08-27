using System;
using System.Collections.Generic;
using Game.Gameplay.Core;
using UnityEngine;

namespace Game.Gameplay.Sensors
{
    public sealed class EnemySensor : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        
        private readonly List<GameObject> _enemies = new();

        public IReadOnlyList<GameObject> Enemies => _enemies;
        
        public event Action<GameObject> OnEnemyEnter;
        public event Action<GameObject> OnEnemyExit; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TeamComponent>().Team == _character.GetComponent<TeamComponent>().Team)
                return;
            
            _enemies.Add(other.gameObject);
            other.GetComponent<HealthComponent>().OnDeath += OnEnemyDied;
            OnEnemyEnter?.Invoke(other.gameObject);
        }

        private void OnEnemyDied()
        {
            GameObject diedEnemy = null;
            foreach (var enemy in _enemies)
            {
                if (enemy.GetComponent<HealthComponent>().IsDead)
                {
                    diedEnemy = enemy;
                    break;
                }
            }

            if (diedEnemy != null) 
                RemoveEnemyFromList(diedEnemy);
        }

        private void RemoveEnemyFromList(GameObject diedEnemy)
        {
            _enemies.Remove(diedEnemy);
            diedEnemy.GetComponent<HealthComponent>().OnDeath -= OnEnemyDied;
            OnEnemyExit?.Invoke(diedEnemy);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TeamComponent>().Team == _character.GetComponent<TeamComponent>().Team)
                return;
            
            RemoveEnemyFromList(other.gameObject);
        }
    }
}