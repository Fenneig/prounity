using UnityEngine;

namespace Game
{
    public class PushDamageAttack : AttackComponent
    {
        [SerializeField] private float _damage = 1f;
        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent = GetComponent<PushComponent>();
        }

        protected override void PerformAttack(Rigidbody2D target)
        {
            if (target.TryGetComponent(out HealthComponent healthComponent))
                healthComponent.TakeDamage(_damage);
            
            _pushComponent.Push(target);
        }
    }
}