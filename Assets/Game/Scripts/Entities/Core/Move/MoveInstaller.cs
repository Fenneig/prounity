using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class MoveInstaller : IEntityInstaller
    {
        [SerializeField] private Const<float> _moveDuration;
        
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _audioClips;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveableTag();

            entity.AddMoveRequest(new Request<Vector3>());
            entity.AddMoveCommand(new Command<MoveArgs>());
            entity.AddMoveDuration(_moveDuration);
            entity.AddMoveTime(new Variable<float>(-_moveDuration));
            
            entity.AddBehaviour(new MoveBehaviour());
        }
    }
}