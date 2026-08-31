using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class HealthInstaller : IGameEntityInstaller
    {
        [SerializeField] private Const<int> _maxHealth;
        [SerializeField] private ReactiveVariable<int> _health;
        [SerializeField] private HealthParticlesInstaller _healthParticlesInstaller;
        
        public void Install(IGameEntity entity)
        {
            entity.AddDamageableTag();
            entity.SetMaxHealth(_maxHealth);
            entity.SetHealth(_health);
            
            _healthParticlesInstaller.Install(entity);
        }
    }
}