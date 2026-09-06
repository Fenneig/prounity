using Unity.Entities;

namespace Game.GameEntities.Core
{
    public partial struct AttackCooldownSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            
            foreach (var (cooldown, 
                         attackState) 
                     in SystemAPI.Query<
                             RefRW<AttackCooldown>, 
                             RefRW<AttackStateComponent>>()
                         .WithNone<Dead>())
            {
                if (attackState.ValueRO.Value != AttackState.Cooldown)
                    continue;
                
                cooldown.ValueRW.Remaining -= deltaTime;

                if (cooldown.ValueRO.Remaining > 0)
                    continue;

                attackState.ValueRW.Value = AttackState.Ready;
            }
        }
    }
}