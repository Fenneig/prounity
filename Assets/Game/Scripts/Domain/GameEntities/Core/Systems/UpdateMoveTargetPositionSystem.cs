using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    [BurstCompile]
    public partial struct UpdateMoveTargetPositionSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (moveTarget, moveDirection) in SystemAPI.Query<RefRO<MoveTarget>, RefRW<MoveDirection>>())
            {
                Entity targetEntity = moveTarget.ValueRO.Value;
                
                if (!SystemAPI.HasComponent<LocalTransform>(targetEntity))
                    continue;
                
                moveDirection.ValueRW.Value = SystemAPI.GetComponent<LocalTransform>(targetEntity).Position;
            }
        }
    }
}