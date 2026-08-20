using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class PickUpViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private Optional<ParticleSystem> _particleSystem;
        [SerializeField] private Optional<AudioSource> _audioSource;
        
        public override void Install(IEntity entity)
        {
            if (_particleSystem) 
                entity.GetInteractCommand().AddAction(_ => _particleSystem.Value.Play());
            
            if (_audioSource) 
                entity.GetInteractCommand().AddAction(_ => _audioSource.Value.Play());
        }
    }
}