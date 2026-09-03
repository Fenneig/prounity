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

        public void StartAttack()
        {
            _animator.SetTrigger(_animatorKey);
            _audioSource.PlayOneShot(_audioClip);
        }

        public void FinalizeAttack()
        {
            _vfx.Play();
        }
    }
}