using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class HealthInstaller : IEntityInstaller
    {
        [SerializeField] private Const<int> _maxHealth;
        [SerializeField] private ReactiveVariable<int> _health;
        
        public void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.SetMaxHealth(_maxHealth);
            entity.SetHealth(_health);
        }
    }
}