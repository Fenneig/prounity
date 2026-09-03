using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(ForceComponent), typeof(DealDamageComponent))]
    public sealed class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private float _radius = .2f;

        private ForceComponent _forceComponent;
        private DealDamageComponent _dealDamageComponent;
        private float _startAttackTime;
        
        public bool CanAttack => Time.time - _startAttackTime > _cooldown;

        private void Awake()
        {
            _startAttackTime = Time.time;
            
            _forceComponent = GetComponent<ForceComponent>();
            _dealDamageComponent = GetComponent<DealDamageComponent>();
        }

        public void Attack()
        {
            _startAttackTime = Time.time;
            
            var hits = Physics2D.OverlapCircleAll(_attackPoint.position, _radius, _enemyMask);
            foreach (var hit in hits)
            {
                if (_dealDamageComponent.TryDealDamage(hit.gameObject))
                    _forceComponent.ApplyForce(hit);
            }
        }
    }
}