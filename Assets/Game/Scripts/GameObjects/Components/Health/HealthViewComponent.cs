using UnityEngine;

namespace Game
{
    public sealed class HealthViewComponent : MonoBehaviour
    {
        private static readonly int DeathKey = Animator.StringToHash("Death");
        
        [SerializeField] private HealthComponent _health;
        [SerializeField] private TakeDamageColorComponent _takeDamageColor;
        [SerializeField] private Animator _animator;
        
        private void OnEnable()
        {
            _health.OnHealthChanged += TakeDamage;
            _health.OnDied += Death;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= TakeDamage;
            _health.OnDied -= Death;
        }

        private void Death() => _animator.SetTrigger(DeathKey);
        private void TakeDamage(float _) => _takeDamageColor.TakeDamage();
    }
}