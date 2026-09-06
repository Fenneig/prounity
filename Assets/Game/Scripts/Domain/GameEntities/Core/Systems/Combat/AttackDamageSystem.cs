using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    public partial struct AttackDamageSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (target,
                         damage,
                         attackState,
                         attackCooldown) in 
                     SystemAPI.Query<
                         RefRO<CombatTarget>, 
                         RefRO<AttackDamage>, 
                         RefRW<AttackStateComponent>, 
                         RefRW<AttackCooldown>>()
                         .WithPresent<IsInRangeWithTarget>()
                         .WithNone<Dead>())
            {
                if (attackState.ValueRO.Value != AttackState.Attacking)
                    continue;
                
                attackState.ValueRW.Value = AttackState.Ready;
                
                if (target.ValueRO.Value == Entity.Null || !state.EntityManager.Exists(target.ValueRO.Value))
                    continue;
                
                Entity targetEntity = target.ValueRO.Value;
                
                if (targetEntity == Entity.Null)
                    continue;
                
                if (!SystemAPI.HasComponent<Health>(targetEntity))
                    continue;
                
                RefRW<Health> targetHealth = SystemAPI.GetComponentRW<Health>(targetEntity);

                targetHealth.ValueRW.Current -= damage.ValueRO.Value;
                SystemAPI.SetComponentEnabled<IsTakeDamage>(targetEntity, true);
                
                attackCooldown.ValueRW.Remaining = attackCooldown.ValueRO.Duration;
                attackState.ValueRW.Value = AttackState.Cooldown;
            }
        }
    }
}