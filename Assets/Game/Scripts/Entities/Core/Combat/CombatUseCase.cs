using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public static class CombatUseCase
    {
        public static void OverlapSplashDamage(this IEntity entity, Transform initPoint, float attackRadius, int damage, LayerMask layerMask)
        {
            Collider[] colliders = Physics.OverlapSphere(initPoint.position, attackRadius, layerMask);
            foreach (Collider collider in colliders) 
                DealDamage(collider, damage, entity);
        }

        public static bool DealDamage(Collider collider, int amount, IEntity attacker)
        {
            IEntity entity = collider.GetComponentInParent<IEntity>();
            if (entity != null && entity.HasDamageableTag())
            {
                entity.GetTakeDamageAction().Invoke(amount);
                
                if (entity.IsDead())
                    attacker.ProcessKill();
                
                return true;
            }

            return false;
        }
    }
}