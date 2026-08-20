using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Entities
{
    [Serializable]
    public sealed class WeaponViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private Optional<AudioSource> _audioSource;
        [SerializeField] private float _minPitch;
        [SerializeField] private float _maxPitch;
        
        [SerializeField] private Optional<ParticleSystem> _particleSystem;
        [SerializeField] private bool _hasAmmo;

        private readonly DisposableComposite _disposableComposite = new();
        
        public override void Install(IEntity entity)
        {
            if (_audioSource)
            {
                entity.AddAudioSource(_audioSource);
                entity.GetFireCommand().Subscribe(() =>
                {
                    var source = entity.GetAudioSource();
                    source.pitch = Random.Range(_minPitch, _maxPitch);
                    entity.GetAudioSource().Play();
                }).AddTo(_disposableComposite);
            }
            
            if (_particleSystem)
            {
                entity.AddParticleSystem(_particleSystem);
                entity.GetFireCommand().Subscribe(entity.GetParticleSystem().Play).AddTo(_disposableComposite);
            }

            if (_hasAmmo)
            {
                entity.AddBehaviour(new AmmoViewPresenter(GameUI.Instance));
            }
        }

        public override void Uninstall(IEntity entity)
        {
            _disposableComposite.Dispose();
        }
    }
}