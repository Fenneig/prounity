using Game.Common;
using Game.GameEntities.Content;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    public partial struct TargetSearchSystem : ISystem
    { 
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityQuery enemyQuery = SystemAPI.QueryBuilder()
                .WithAll<Unit, Team, LocalTransform>()
                .WithNone<Dead>()
                .Build();
            
            EntityQuery baseQuery = SystemAPI.QueryBuilder()
                .WithAll<Base, Team, LocalTransform>()
                .WithNone<Dead>()
                .Build();
            
            NativeArray<Entity> units = enemyQuery.ToEntityArray(Allocator.Temp);
            NativeArray<Entity> bases = baseQuery.ToEntityArray(Allocator.Temp);
            
            NativeArray<Team> teams = enemyQuery.ToComponentDataArray<Team>(Allocator.Temp);
            NativeArray<Team> basesTeams = baseQuery.ToComponentDataArray<Team>(Allocator.Temp);
            
            NativeArray<LocalTransform> transforms = enemyQuery.ToComponentDataArray<LocalTransform>(Allocator.Temp);
            NativeArray<LocalTransform> basesTransforms = baseQuery.ToComponentDataArray<LocalTransform>(Allocator.Temp);

            foreach (var (transform,
                         team,
                         combatTarget, 
                         request) in 
                     SystemAPI.Query<
                         RefRO<LocalTransform>, 
                         RefRO<Team>, 
                         RefRW<CombatTarget>, 
                         EnabledRefRW<SearchTargetRequest>>()
                         .WithPresent<SearchTargetRequest>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                request.ValueRW = false;
                
                var isCurrentTargetValid = combatTarget.ValueRO.Value != Entity.Null &&
                                   state.EntityManager.Exists(combatTarget.ValueRO.Value) &&
                                   !state.EntityManager.HasComponent<Dead>(combatTarget.ValueRO.Value);
                
                if (isCurrentTargetValid)
                    continue;

                Entity newTarget = FindClosestEnemy(transform.ValueRO.Position, team.ValueRO, units, teams, transforms);
                
                if (newTarget == Entity.Null)
                    newTarget = FindClosestEnemy(transform.ValueRO.Position, team.ValueRO, bases, basesTeams, basesTransforms);
                
                combatTarget.ValueRW.Value = newTarget;
            }
        }

        private Entity FindClosestEnemy(float3 position, Team team, NativeArray<Entity> candidates,
            NativeArray<Team> candidatesTeam, NativeArray<LocalTransform> candidatesTransform)
        {
            float closetsDistance = float.MaxValue;
            Entity closestEntity = Entity.Null;
                
            for (int i = 0; i < candidates.Length; i++)
            {
                if (candidatesTeam[i].Value == team.Value)
                    continue;

                float3 enemyPosition = candidatesTransform[i].Position;
                    
                float distanceSq = math.distancesq(position, enemyPosition);

                if (distanceSq < closetsDistance)
                {
                    closetsDistance = distanceSq;
                    closestEntity = candidates[i];
                }
            }

            return closestEntity;
        }
    }
}