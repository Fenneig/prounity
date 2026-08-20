using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class HealthViewInstaller : IEntityInstaller
    {
        [SerializeField] private ParticleSystem _bloodParticle;
        [SerializeField] private ParticleSystem _deadParticle;
        
        public virtual void Install(IEntity entity)
        {
            entity.AddBloodParticle(_bloodParticle);
            entity.AddDeadParticle(_deadParticle);
        }
    }
}