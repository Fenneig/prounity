using System;
using Game.Utils;
using UnityEngine;

namespace Game.Damage
{
    public sealed class DamageComponent : MonoBehaviour
    {
        public event Action OnDamageApplied;
        private int _damage;
        private TeamType _team;

        public void Init(int damage, TeamType teamType)
         {
            _damage = damage;
            _team = teamType;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable) &&
                damageable.Team != _team)
            {
                damageable.ApplyDamage(_damage);
                OnDamageApplied?.Invoke();
            }
        }
    }
}