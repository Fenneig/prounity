using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    public partial struct UpdateMoveTargetPositionSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (moveTarget, moveDirection, moveRequest, isInRangeWithTarget) in 
                     SystemAPI.Query<RefRO<MoveTarget>, RefRW<MoveDestination>, EnabledRefRW<MoveDestination>, EnabledRefRO<IsInRangeWithTarget>>()
                         .WithPresent<IsInRangeWithTarget>()
                         .WithPresent<MoveDestination>()
                         .WithNone<Dead>())
            {
                if (isInRangeWithTarget.ValueRO)
                {
                    moveRequest.ValueRW = false;
                    continue;
                }

                Entity targetEntity = moveTarget.ValueRO.Value;

                if (targetEntity == Entity.Null)
                {
                    moveRequest.ValueRW = false;
                    continue;
                }

                if (!SystemAPI.HasComponent<LocalTransform>(targetEntity))
                {                  
                    moveRequest.ValueRW = false;
                    continue;
                }

                moveDirection.ValueRW.Value = SystemAPI.GetComponent<LocalTransform>(targetEntity).Position;
                moveRequest.ValueRW = true;
            }
        }
    }
}