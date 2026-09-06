using Game.GameEntities.Content;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    public partial struct AttackRangeSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var transformLookup = SystemAPI.GetComponentLookup<LocalTransform>(true);
            
            foreach (var (transform, 
                         attackRange, 
                         combatTarget, 
                         isInRange) in
                     SystemAPI.Query<
                         RefRO<LocalTransform>, 
                         RefRO<Range>, 
                         RefRW<CombatTarget>,
                         EnabledRefRW<IsInRangeWithTarget>>()
                         .WithAll<Unit>()
                         .WithPresent<IsInRangeWithTarget>()
                         .WithNone<Dead>())
            {
                Entity target = combatTarget.ValueRO.Value;

                if (target == Entity.Null || !state.EntityManager.Exists(target) || !transformLookup.HasComponent(target))
                {
                    combatTarget.ValueRW.Value = Entity.Null;
                    isInRange.ValueRW = false;
                    continue;
                }
                
                var targetPosition = transformLookup[target].Position;
                float distanceSq = math.distancesq(transform.ValueRO.Position, targetPosition);
                
                float range = attackRange.ValueRO.Value;
                
                isInRange.ValueRW = distanceSq <= range * range;
            }
        }
    }
}