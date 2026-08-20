using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class ZombieViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private HealthViewInstaller _healthViewInstaller;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Const<List<AudioClip>> _painSounds;
        [SerializeField] private Const<List<AudioClip>> _deathSounds;
        [SerializeField] private Const<List<AudioClip>> _attackSounds;
        [SerializeField] private Const<List<AudioClip>> _shoutSounds;
        [SerializeField] private Const<List<AudioClip>> _bodyFallSounds;
        
        
        public override void Install(IEntity entity)
        {
            _healthViewInstaller.Install(entity);
            entity.AddAnimator(_animator);

            entity.AddBehaviour(new MoveAnimBehaviour());
            entity.AddBehaviour(new HealthViewBehaviour());
            entity.AddBehaviour(new MeleeAnimBehaviour());

            entity.AddAudioSource(_audioSource);
            entity.AddAttackAudioClips(_attackSounds);
            
            HealthSoundInstall(entity);
            BodyFallSoundInstall(entity);
            AttackSoundInstall(entity);
            ShoutSoundInstall(entity);
        }

        private void BodyFallSoundInstall(IEntity entity)
        {
            entity.AddBodyFallSoundRequest(new Request());
            entity.AddBodyFallSoundCommand(new Command()
                .AddAction(() => entity.PlayRandomSound(_audioSource, _bodyFallSounds)));
            entity.AddBehaviour(new BodyFallSoundBehaviour());
        }

        private void HealthSoundInstall(IEntity entity)
        {
            entity.AddPainAudioClips(_painSounds);
            entity.AddDeathAudioClips(_deathSounds);
        }

        private void AttackSoundInstall(IEntity entity)
        {
            entity.AddAttackSoundRequest(new Request());
            entity.AddAttackSoundCommand(new Command()
                .AddAction(() => entity.PlayRandomSound(_audioSource, _attackSounds)));
            entity.AddBehaviour(new AttackSoundBehaviour());
        }

        private void ShoutSoundInstall(IEntity entity)
        {
            entity.AddShoutSoundRequest(new Request());
            entity.AddShoutSoundCommand(new Command()
                .AddAction(() => entity.PlayRandomSound(_audioSource, _shoutSounds)));
            entity.AddBehaviour(new ShoutSoundBehaviour());
        }
    }
}