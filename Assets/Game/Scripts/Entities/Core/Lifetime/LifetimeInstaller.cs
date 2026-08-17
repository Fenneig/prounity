using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class LifetimeInstaller : IEntityInstaller
    {
        [SerializeField] private Cooldown _cooldown;
        
        public void Install(IEntity entity)
        {
            entity.AddLifetime(_cooldown);
            entity.AddBehaviour(new LifetimeBehaviour());
        }
    }
}