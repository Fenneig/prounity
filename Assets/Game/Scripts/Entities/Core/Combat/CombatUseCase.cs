using UnityEngine;

namespace Game.Entities
{
    public static class CombatUseCase
    {
        public static void OverlapSplashDamage(this IGameEntity entity, Transform initPoint, float attackRadius, int damage, LayerMask layerMask)
        {
            Collider[] colliders = Physics.OverlapSphere(initPoint.position, attackRadius, layerMask);
            foreach (Collider collider in colliders) 
                DealDamage(collider, damage, entity);
        }

        public static bool DealDamage(Collider collider, int amount, IGameEntity attacker)
        {
            IGameEntity entity = collider.GetComponentInParent<IGameEntity>();
            if (entity != null && entity.HasDamageableTag())
            {
                entity.GetTakeDamageAction().Invoke(amount);

                if (entity.IsDead() && entity.HasScorableTag())
                    attacker.ProcessKill();
                
                return true;
            }

            return false;
        }
    }
}