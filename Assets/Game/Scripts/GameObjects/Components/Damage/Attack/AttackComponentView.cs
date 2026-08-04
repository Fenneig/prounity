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

        private AttackRequestComponent _attackRequestComponent;

        private void Awake() => _attackRequestComponent = GetComponent<AttackRequestComponent>();
        private void OnEnable() => _attackRequestComponent.OnAttack += Attack;
        private void OnDisable() => _attackRequestComponent.OnAttack -= Attack;

        private void Attack()
        {
            _animator.SetTrigger(_animatorKey);
            _vfx.Play();
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}