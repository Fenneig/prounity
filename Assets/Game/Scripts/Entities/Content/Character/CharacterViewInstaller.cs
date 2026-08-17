using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CharacterViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Const<List<AudioClip>> _moveClips;
        [SerializeField] private Const<List<AudioClip>> _painSounds;
        [SerializeField] private Const<List<AudioClip>> _deathSounds;
        [SerializeField] private Const<List<AudioClip>> _bodyFallSounds;
        
        public override void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddAudioSource(_audioSource);
            
            entity.AddBehaviour(new MoveAnimBehaviour());
            entity.AddBehaviour(new FireAnimBehaviour());
            entity.AddBehaviour(new HealthAnimBehaviour());
            
            MoveSoundInstall(entity);
            BodyFallSoundInstall(entity);
            HealthSoundInstall(entity);
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

        private void MoveSoundInstall(IEntity entity)
        {
            entity.AddMoveSoundRequest(new Request());
            entity.AddMoveAudioClips(_moveClips);
            //entity.AddMoveSoundCommand(new Command().AddAction(() => entity.PlayRandomSound(_audioSource, _moveClips)));
            entity.AddBehaviour(new MoveSoundBehaviour());
        }
    }
}