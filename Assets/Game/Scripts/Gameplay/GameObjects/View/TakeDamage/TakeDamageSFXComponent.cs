using Game.Gameplay.Core;
using UnityEngine;

namespace Game.Gameplay.View
{
    public sealed class TakeDamageSFXComponent : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private TakeDamageComponent _takeDamageComponent;

        [SerializeField]
        private AudioClip _audioClip;

        private void OnEnable()
        {
            _takeDamageComponent.OnDamageTaken += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            _takeDamageComponent.OnDamageTaken -= this.OnDamageTaken;
        }

        private void OnDamageTaken(TakeDamageArgs args)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}