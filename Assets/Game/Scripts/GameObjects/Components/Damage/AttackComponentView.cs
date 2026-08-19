using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public sealed class AttackComponentView : MonoBehaviour
    {
        [Header("Animator")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animatorKey;
        [Header("Visual")]
        [SerializeField] private ParticleSystem _vfx;
        [Header("Audio")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        public bool IsPlaying { get; private set; }

        public IEnumerator Attack(float animationAnticipation, Action onHit)
        {
            IsPlaying = true;
            _animator.SetTrigger(_animatorKey);
            _audioSource.PlayOneShot(_audioClip);
            
            yield return new WaitForSeconds(animationAnticipation);
            
            IsPlaying = false;
            _vfx.Play();
            onHit();
        }
    }
}