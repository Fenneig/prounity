using Game.GameEntities.Content;
using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    public partial struct StartAttackSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (target,
                         anticipation, 
                         attackState, 
                         animationRequest)
                     in SystemAPI.Query<
                         RefRO<CombatTarget>, 
                         RefRW<AttackAnticipation>, 
                         RefRW<AttackStateComponent>,
                         EnabledRefRW<AttackAnimationRequest>>()
                         .WithPresent<AttackAnimationRequest>()
                         .WithAll<IsInRangeWithTarget>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                if (attackState.ValueRO.Value != AttackState.Ready)
                    continue;
                
                Entity targetEntity = target.ValueRO.Value;
                
                if (targetEntity == Entity.Null || !state.EntityManager.Exists(targetEntity)) 
                    continue;

                anticipation.ValueRW.Remaining = anticipation.ValueRO.Duration;
                attackState.ValueRW.Value = AttackState.Preparing;
                
                animationRequest.ValueRW = true;
            }
        }
    }
}