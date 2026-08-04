using UnityEngine;

namespace Game
{
    public sealed class HealthViewComponent : MonoBehaviour
    {
        private static readonly int DeathKey = Animator.StringToHash("Death");
        private HealthComponent _health;
        private TakeDamageColorComponent _takeDamageColor;
        private Animator _animator;
        
        private void Awake()
        {
            _health = GetComponentInChildren<HealthComponent>();
            _takeDamageColor = GetComponentInChildren<TakeDamageColorComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

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