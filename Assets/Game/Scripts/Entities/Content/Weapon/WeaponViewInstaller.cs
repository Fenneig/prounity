using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class WeaponViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private Optional<AudioSource> _audioSource;
        [SerializeField] private Optional<ParticleSystem> _particleSystem;

        private readonly DisposableComposite _disposableComposite = new();
        
        public override void Install(IEntity entity)
        {
            if (_audioSource)
            {
                entity.AddAudioSource(_audioSource);
                entity.GetFireCommand().Subscribe(entity.GetAudioSource().Play).AddTo(_disposableComposite);
            }
            
            if (_particleSystem)
            {
                entity.AddParticleSystem(_particleSystem);
                entity.GetFireCommand().Subscribe(entity.GetParticleSystem().Play).AddTo(_disposableComposite);
            }
        }

        public override void Uninstall(IEntity entity)
        {
            _disposableComposite.Dispose();
        }
    }
}