using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    public partial struct DeathSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);

            foreach (var (health, entity) in SystemAPI.Query<RefRO<Health>>().WithNone<Dead>().WithEntityAccess())
            {
                if (health.ValueRO.Current > 0)
                    continue;
                
                ecb.AddComponent<Dead>(entity);
            }
        }
    }
}