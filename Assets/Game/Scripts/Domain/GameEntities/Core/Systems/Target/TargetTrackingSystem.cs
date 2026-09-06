using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    public partial struct TargetTrackingSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (combatTarget, moveTarget) in SystemAPI.Query<RefRO<CombatTarget>, RefRW<MoveTarget>>())
            {
                Entity target = combatTarget.ValueRO.Value;
                
                if (target == Entity.Null || !state.EntityManager.Exists(target))
                    continue;
                
                if (!SystemAPI.HasComponent<LocalTransform>(target))
                    continue;
                
                moveTarget.ValueRW.Value = target;
            }
        }
    }
}