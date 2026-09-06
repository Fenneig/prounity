using Game.GameEntities.Content;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct TransformViewSyncSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transformRef, transform) in SystemAPI.Query<RefRW<TransformReference>, RefRO<LocalTransform>>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                transformRef.ValueRW.Value.position = transform.ValueRO.Position;
                transformRef.ValueRW.Value.rotation = transform.ValueRO.Rotation;
            }
        }
    }
}