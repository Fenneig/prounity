using UnityEngine;

namespace Game.Entities
{
    public static class HealthUseCase
    {
        public static void TakeDamage(this IGameEntity entity, int damage)
        {
            if (IsHealthExists(entity))
            {
                var health = entity.GetHealth();
                health.Value = Mathf.Max(0, health.Value - damage);
            }
        }

        public static void Heal(this IGameEntity entity, int amount)
        {
            if (IsHealthExists(entity))
            {
                var health = entity.GetHealth();
                var maxHealth = entity.GetMaxHealth();
                health.Value = Mathf.Min(health.Value + amount, maxHealth.Value);
            }
        }
        
        public static bool CanHealTarget(this IGameEntity target) =>
            target.HasCharacterTag() && 
            target.IsHealthExists() &&
            target.GetHealth().Value < target.GetMaxHealth().Value;

        public static bool IsHealthExists(this IGameEntity entity) => entity.GetHealth().Value > 0;
        public static bool IsDead(this IGameEntity entity) => entity.GetHealth().Value <= 0;
        
        public static float GetHealthPercent(this IGameEntity entity) => 
            (float)entity.GetHealth().Value / entity.GetMaxHealth().Value;
    }
}