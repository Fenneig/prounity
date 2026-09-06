using Game.GameEntities.Content;
using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    public partial struct AttackAnticipationSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (anticipation, attackState) in SystemAPI.Query<
                             RefRW<AttackAnticipation>,
                             RefRW<AttackStateComponent>>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                if (attackState.ValueRO.Value != AttackState.Preparing)
                    continue;

                anticipation.ValueRW.Remaining -= deltaTime;

                if (anticipation.ValueRO.Remaining > 0)
                    continue;

                attackState.ValueRW.Value = AttackState.Attacking;
            }
        }
    }
}