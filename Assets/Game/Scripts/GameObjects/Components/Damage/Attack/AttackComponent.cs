using UnityEngine;

namespace Game
{
    public abstract class AttackComponent : MonoBehaviour
    {
        [SerializeField] private Transform _attackPoint;

        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private float _detectRadius = .2f;
        
        public void Attack()
        {
            var target = DetectTarget();
            
            if (target == null)
                return;

            PerformAttack(target);
        }

        private Rigidbody2D DetectTarget()
        {
            var hit = Physics2D.OverlapCircle(_attackPoint.position, _detectRadius, _enemyMask);
            return hit != null ? hit.GetComponent<Rigidbody2D>() : null;
        }

        protected abstract void PerformAttack(Rigidbody2D target);
    }
}