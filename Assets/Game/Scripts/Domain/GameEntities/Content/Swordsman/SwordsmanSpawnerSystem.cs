using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.GameEntities.Content
{
    [BurstCompile]
    public partial struct SwordsmanSpawnerSystem : ISystem
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
            
            foreach (var (spawner, spawnerEntity) in SystemAPI.Query<RefRO<SwordsmanSpawner>>().WithEntityAccess())
            {
                int width = 10;
                
                for (int i = 0; i < spawner.ValueRO.Count; i++)
                {
                    Entity swordsmanEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);

                    int x = i % width;
                    int z = i / width;
                    
                    float3 position = new float3(x * spawner.ValueRO.Spacing, 0, z * spawner.ValueRO.Spacing);
                    
                    ecb.SetComponent(swordsmanEntity, LocalTransform.FromPosition(position));
                }

                ecb.DestroyEntity(spawnerEntity);
            }
        }
    }
}