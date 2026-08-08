using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(ForceComponent), typeof(DealDamageComponent))]
    public sealed class PushDamageWeapon : WeaponBaseComponent
    {
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private float _radius = .2f;

        private ForceComponent _forceComponent;
        private DealDamageComponent _dealDamageComponent;

        protected override void Awake()
        {
            base.Awake();

            _forceComponent = GetComponent<ForceComponent>();
            _dealDamageComponent = GetComponent<DealDamageComponent>();
        }

        protected override void PerformAttack()
        {
            var hits = Physics2D.OverlapCircleAll(_attackPoint.position, _radius, _enemyMask);
            foreach (var hit in hits)
            {
                if (_dealDamageComponent.TryDealDamage(hit.gameObject))
                    _forceComponent.ApplyForce(hit);
            }
        }
    }
}