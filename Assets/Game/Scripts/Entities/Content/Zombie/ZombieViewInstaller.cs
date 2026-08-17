using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class ZombieViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Const<List<AudioClip>> _painSounds;
        [SerializeField] private Const<List<AudioClip>> _deathSounds;
        [SerializeField] private Const<List<AudioClip>> _attackSounds;
        [SerializeField] private Const<List<AudioClip>> _bodyFallSounds;
        
        
        public override void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            //entity.GetFireAnticipation()

            entity.AddBehaviour(new MoveAnimBehaviour());
            entity.AddBehaviour(new HealthAnimBehaviour());

            entity.AddAudioSource(_audioSource);
            entity.AddAttackAudioClips(_attackSounds);
            
            HealthSoundInstall(entity);
            BodyFallSoundInstall(entity);
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
            entity.AddBehaviour(new HealthSoundBehaviour());
            entity.AddPainAudioClips(_painSounds);
            entity.AddDeathAudioClips(_deathSounds);
        }

        private void ShoutSoundInstall(IEntity entity)
        {
            entity.AddAttackSoundRequest(new Request());
            entity.AddAttackSoundCommand(new Command()
                .AddAction(() => entity.PlayRandomSound(_audioSource, _bodyFallSounds)));
            entity.AddBehaviour(new AttackSoundBehaviour());
        }
    }
}