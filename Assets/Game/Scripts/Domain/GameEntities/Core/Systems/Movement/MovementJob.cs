using Game.GameEntities.Content;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    [WithPresent(typeof(IsInRangeWithTarget))]
    public partial struct MovementJob : IJobEntity
    {
        public float DeltaTime;
        
        [BurstCompile]
        private void Execute(
            ref LocalTransform transform,
            in MoveDestination target,
            in MoveSpeed speed,
            in Unit unit,
            EnabledRefRO<IsInRangeWithTarget> isInTargetRange)
        {
            if (isInTargetRange.ValueRO)
                return;
            
            float3 position = transform.Position;
            float3 targetPosition = target.Value;

            float3 offset = targetPosition - position;
            float distance = math.length(offset);

            if (distance <= 1f)
                return;

            float3 direction = offset / distance;

            float moveDistance = speed.Value * DeltaTime;

            moveDistance = math.min(moveDistance, distance);

            transform.Position += direction * moveDistance;
        }
    }
}