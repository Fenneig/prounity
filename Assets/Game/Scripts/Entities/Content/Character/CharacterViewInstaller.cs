using System.Collections.Generic;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CharacterViewInstaller : GameEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Const<List<AudioClip>> _moveClips;
        [SerializeField] private Const<List<AudioClip>> _painSounds;
        [SerializeField] private Const<List<AudioClip>> _deathSounds;
        [SerializeField] private Const<List<AudioClip>> _bodyFallSounds;
        
        public override void Install(IGameEntity entity)
        {
            entity.AddAnimator(_animator);
            
            entity.AddBehaviour(new MoveAnimBehaviour());
            entity.AddBehaviour(new FireAnimBehaviour());
            entity.AddBehaviour(new HealthViewBehaviour());

            SoundsInstall(entity);
            MoveSoundInstall(entity);
            BodyFallSoundInstall(entity);
        }

        private void SoundsInstall(IGameEntity entity)
        {
            entity.AddPainAudioClips(_painSounds);
            entity.AddDeathAudioClips(_deathSounds);
            entity.AddMoveAudioClips(_moveClips);
            entity.AddAudioSource(_audioSource);
        }

        private void BodyFallSoundInstall(IGameEntity entity)
        {
            entity.AddBodyFallSoundRequest(new Request());
            entity.AddBodyFallSoundCommand(new Command()
                .AddAction(() => entity.PlayRandomSound(_audioSource, _bodyFallSounds)));
            entity.AddBehaviour(new BodyFallSoundBehaviour());
        }

        private void MoveSoundInstall(IGameEntity entity)
        {
            entity.AddMoveSoundRequest(new Request());
            entity.AddBehaviour(new MoveSoundBehaviour());
        }
    }
}