using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class HealthViewBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        
        private Animator _animator;
        private IReactiveVariable<int> _health;
        
        private AudioSource _audioSource;
        private IValue<List<AudioClip>> _painSounds;
        private IValue<List<AudioClip>> _deathSounds;
        private ParticleSystem _bloodParticle;
        private ParticleSystem _deadParticle;
        
        private int _lastHealth;

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _health = entity.GetHealth();
            _audioSource = entity.GetAudioSource();
            _painSounds = entity.GetPainAudioClips();
            _deathSounds = entity.GetDeathAudioClips();
            _bloodParticle = entity.GetBloodParticle();
            _deadParticle = entity.GetDeadParticle();
            
            _lastHealth = _health.Value;
            
            _health.OnEvent += HealthChanged;
        }

        private void HealthChanged(int newHealth)
        {
            if (newHealth == 0)
            {
                _animator.SetTrigger(Death);
                _audioSource.PlayOneShot(GetRandomSound(_deathSounds.Value));
                _deadParticle.Play();
            }
            else 
            {
                if (newHealth < _lastHealth)
                {
                    _animator.SetTrigger(TakeDamage);
                    _audioSource.PlayOneShot(GetRandomSound(_painSounds.Value));
                    _bloodParticle.Play();
                }
                
                _lastHealth = newHealth;
            }
        }
        
        private AudioClip GetRandomSound(List<AudioClip> list) => list[Random.Range(0, list.Count)];

        public void Dispose(IEntity entity)
        {
            _health.OnEvent -= HealthChanged;
        }
    }
}