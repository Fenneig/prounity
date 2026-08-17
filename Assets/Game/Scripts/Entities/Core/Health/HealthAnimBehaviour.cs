using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class HealthAnimBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        
        private Animator _animator;
        private IReactiveVariable<int> _health;
        
        private int _lastHealth;

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _health = entity.GetHealth();
            
            _lastHealth = _health.Value;
            
            _health.OnEvent += HealthChanged;
        }

        private void HealthChanged(int newHealth)
        {
            if (newHealth == 0)
            {
                _animator.SetTrigger(Death);
            }
            else 
            {
                if (newHealth < _lastHealth) 
                    _animator.SetTrigger(TakeDamage);
                
                _lastHealth = newHealth;
            }
        }

        public void Dispose(IEntity entity)
        {
            _health.OnEvent -= HealthChanged;
        }
    }
}