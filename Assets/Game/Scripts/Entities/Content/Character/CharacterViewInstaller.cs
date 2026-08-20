using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using Game.Entities.Score;
using Game.UI;
using UnityEngine;

namespace Game.Entities
{
    public sealed class CharacterViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private CharacterHealthViewInstaller _characterHealthViewInstaller;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Const<List<AudioClip>> _moveClips;
        [SerializeField] private Const<List<AudioClip>> _painSounds;
        [SerializeField] private Const<List<AudioClip>> _deathSounds;
        [SerializeField] private Const<List<AudioClip>> _bodyFallSounds;
        
        public override void Install(IEntity entity)
        {
            _characterHealthViewInstaller.Install(entity);
            
            entity.AddAnimator(_animator);
            
            entity.AddBehaviour(new MoveAnimBehaviour());
            entity.AddBehaviour(new FireAnimBehaviour());
            entity.AddBehaviour(new HealthViewBehaviour());
            entity.AddBehaviour(new ScoreViewPresenter(GameUI.Instance));

            SoundsInstall(entity);
            MoveSoundInstall(entity);
            BodyFallSoundInstall(entity);
        }

        private void SoundsInstall(IEntity entity)
        {
            entity.AddPainAudioClips(_painSounds);
            entity.AddDeathAudioClips(_deathSounds);
            entity.AddMoveAudioClips(_moveClips);
            entity.AddAudioSource(_audioSource);
        }

        private void BodyFallSoundInstall(IEntity entity)
        {
            entity.AddBodyFallSoundRequest(new Request());
            entity.AddBodyFallSoundCommand(new Command()
                .AddAction(() => entity.PlayRandomSound(_audioSource, _bodyFallSounds)));
            entity.AddBehaviour(new BodyFallSoundBehaviour());
        }

        private void MoveSoundInstall(IEntity entity)
        {
            entity.AddMoveSoundRequest(new Request());
            entity.AddBehaviour(new MoveSoundBehaviour());
        }
    }
}