using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class HealthSoundBehaviour : IEntityInit, IEntityDispose
    {
        private IReactiveVariable<int> _health;
        private AudioSource _audioSource;
        private IValue<List<AudioClip>> _painSounds;
        private IValue<List<AudioClip>> _deathSounds;
        
        private int _lastHealth;

        public void Init(IEntity entity)
        {
            _health = entity.GetHealth();
            _audioSource = entity.GetAudioSource();
            _painSounds = entity.GetPainAudioClips();
            _deathSounds = entity.GetDeathAudioClips();
            
            _lastHealth = _health.Value;
            
            _health.OnEvent += HealthChanged;
        }

        private void HealthChanged(int newHealth)
        {
            if (newHealth == 0)
            {
                _audioSource.PlayOneShot(_deathSounds.Value[Random.Range(0, _deathSounds.Value.Count)]);
            }
            else 
            {
                if (newHealth < _lastHealth) 
                    _audioSource.PlayOneShot(_painSounds.Value[Random.Range(0, _painSounds.Value.Count)]);
                
                _lastHealth = newHealth;
            }
        }

        public void Dispose(IEntity entity)
        {
            _health.OnEvent -= HealthChanged;
        }
    }
}