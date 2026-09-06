using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    public partial struct UpdateRotateDirectionSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (moveTarget, rotateDirection) in SystemAPI.Query<RefRO<MoveTarget>, RefRW<RotateDirection>>().WithNone<Dead>())
            {
                Entity targetEntity = moveTarget.ValueRO.Value;

                if (!SystemAPI.HasComponent<LocalTransform>(targetEntity))
                    continue;

                rotateDirection.ValueRW.Value = SystemAPI.GetComponent<LocalTransform>(targetEntity).Position;
            }
        }
    }
}