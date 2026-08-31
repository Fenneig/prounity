using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public class PickUpViewInstaller : GameEntityInstaller
    {
        [SerializeField] private Optional<ParticleSystem> _particleSystem;
        [SerializeField] private Optional<AudioSource> _audioSource;
        
        public override void Install(IGameEntity entity)
        {
            if (_particleSystem) 
                entity.GetInteractCommand().AddAction(_ => _particleSystem.Value.Play());
            
            if (_audioSource) 
                entity.GetInteractCommand().AddAction(_ => _audioSource.Value.Play());
        }
    }
}