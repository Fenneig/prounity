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
                DealDamage(collider, damage);
                
        }

        public static bool DealDamage(Collider collider, int amount)
        {
            IEntity entity = collider.GetComponentInParent<IEntity>();
            if (entity != null && entity.HasDamageableTag())
            {
                entity.GetTakeDamageAction().Invoke(amount);
                return true;
            }

            return false;
        }
    }
}