using System;
using Game.GameObjects.Ships;
using Game.Systems;
using Game.Utils;
using UnityEngine;

namespace Game.GameObjects.Components
{
    public sealed class HealthComponent : MonoBehaviour, IDamageable
    {
        public delegate void HealthChanged(int oldHealth, int newHealth, int maxHealth);

        private int _maxHealth;
        private int _currentCurrentHealth;

        public event HealthChanged OnDamaged;
        public event Action<Ship> OnDead;

        private TeamType _team;

        public TeamType Team => _team;
        public int CurrentHealth => _currentCurrentHealth;
        
        public void Initialize(ShipConfig shipConfig)
        {
            _team = shipConfig.Team;
            _currentCurrentHealth = shipConfig.Health;
            _maxHealth = shipConfig.Health;
        }

        public void ApplyDamage(int amount)
        {
            if (amount <= 0)
                return;

            int oldValue = _currentCurrentHealth;
            _currentCurrentHealth -= amount;
            OnDamaged?.Invoke(oldValue, _currentCurrentHealth, _maxHealth);
            
            if (_currentCurrentHealth <= 0) 
                OnDead?.Invoke(GetComponent<Ship>());
        }
    }
}