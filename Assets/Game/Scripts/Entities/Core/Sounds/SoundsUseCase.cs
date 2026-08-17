using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public static class SoundsUseCase
    {
        public static void PlayRandomSound(this IEntity entity, AudioSource source, List<AudioClip> clips)
        {
            var randomSound = clips[Random.Range(0, clips.Count)];
            entity.PlaySound(source, randomSound);
        }

        public static void PlaySound(this IEntity entity, AudioSource source, AudioClip clip) => 
            source.PlayOneShot(clip);
    }
}