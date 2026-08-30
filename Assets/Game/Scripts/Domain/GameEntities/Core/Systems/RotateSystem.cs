using Unity.Burst;
using Unity.Entities;

namespace Game.GameEntities.Core
{
    [BurstCompile]
    public partial struct RotateSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var job = new RotateJob
            {
                DeltaTime = SystemAPI.Time.DeltaTime
            };

            state.Dependency = job.ScheduleParallel(state.Dependency);
        }
    }
}