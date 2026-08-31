using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class LifetimeInstaller : IGameEntityInstaller
    {
        [SerializeField] private Cooldown _cooldown;
        
        public void Install(IGameEntity entity)
        {
            entity.AddLifetime(_cooldown);
            entity.AddBehaviour(new LifetimeBehaviour());
        }
    }
}