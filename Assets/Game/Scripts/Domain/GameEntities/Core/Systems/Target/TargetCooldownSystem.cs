using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    public partial struct TargetCooldownSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (searchTargetCooldown, 
                         searchTargetRequest) in 
                     SystemAPI.Query<
                         RefRW<SearchTargetCooldown>, 
                         EnabledRefRW<SearchTargetRequest>>())
            {
                searchTargetCooldown.ValueRW.Remaining -= deltaTime;

                if (searchTargetCooldown.ValueRO.Remaining < 0)
                {
                    searchTargetRequest.ValueRW = true;
                    searchTargetCooldown.ValueRW.Remaining = searchTargetCooldown.ValueRO.Duration;
                }
            }
        }
    }
}