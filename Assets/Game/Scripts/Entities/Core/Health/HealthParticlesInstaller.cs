using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class HealthParticlesInstaller : IGameEntityInstaller
    {
        [SerializeField] private ParticleSystem _bloodParticle;
        [SerializeField] private ParticleSystem _deadParticle;
        
        public virtual void Install(IGameEntity entity)
        {
            entity.AddBloodParticle(_bloodParticle);
            entity.AddDeadParticle(_deadParticle);
        }
    }
}