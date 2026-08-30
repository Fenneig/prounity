using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    [BurstCompile]
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var job = new MovementJob
            {
                DeltaTime = SystemAPI.Time.DeltaTime,
            };
            
            state.Dependency = job.ScheduleParallel(state.Dependency);
        }
    }
}