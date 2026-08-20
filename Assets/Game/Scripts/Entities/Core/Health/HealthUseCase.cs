using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public static class HealthUseCase
    {
        public static void TakeDamage(this IEntity entity, int damage)
        {
            if (IsHealthExists(entity))
            {
                var health = entity.GetHealth();
                health.Value = Mathf.Max(0, health.Value - damage);
            }
        }

        public static void Heal(this IEntity entity, int amount)
        {
            if (IsHealthExists(entity))
            {
                var health = entity.GetHealth();
                var maxHealth = entity.GetMaxHealth();
                health.Value = Mathf.Min(health.Value + amount, maxHealth.Value);
            }
        }
        
        public static bool CanHealTarget(this IEntity target) =>
            target.HasCharacterTag() && 
            target.IsHealthExists() &&
            target.GetHealth().Value < target.GetMaxHealth().Value;

        public static bool IsHealthExists(this IEntity entity) => entity.GetHealth().Value > 0;
        public static bool IsDead(this IEntity entity) => entity.GetHealth().Value <= 0;
    }
}