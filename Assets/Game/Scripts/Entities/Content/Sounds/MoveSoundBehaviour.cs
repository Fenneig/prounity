using System.Collections.Generic;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public class MoveSoundBehaviour : IGameEntityInit, IGameEntityTick
    {
        private AudioSource _audioSource;
        private IValue<List<AudioClip>> _moveClips;
        private IRequest _request;
        
        private Queue<AudioClip> _clipQueue;

        public void Init(IGameEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _moveClips = entity.GetMoveAudioClips();
            _request = entity.GetMoveSoundRequest();
            
            _clipQueue = new Queue<AudioClip>();

            RandomizeClips();
        }

        private void RandomizeClips()
        {
            _clipQueue.Clear();
            List<AudioClip> clips = new List<AudioClip>(_moveClips.Value);
            Shuffle(clips);
            foreach (var clip in clips) 
                _clipQueue.Enqueue(clip);
        }

        private void Shuffle(List<AudioClip> clips)
        {
            for (int i = clips.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                (clips[i], clips[randomIndex]) = (clips[randomIndex], clips[i]);
            }
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (!_request.Consume()) 
                return;
            
            if (_clipQueue.Count > 0)
                entity.PlaySound(_audioSource, _clipQueue.Dequeue());
            else
                RandomizeClips();
        }
    }
}