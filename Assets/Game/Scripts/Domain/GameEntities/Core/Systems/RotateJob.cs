using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.GameEntities.Core
{
    [BurstCompile]
    public partial struct RotateJob : IJobEntity
    {
        public float DeltaTime;

        private void Execute(ref LocalTransform transform, in RotateDirection target, in RotateSpeed speed)
        {
            float3 direction = target.Value - transform.Position;

            direction.y = 0;
            float lengthSq = math.lengthsq(direction);
            
            if (lengthSq < .0001f)
                return;
            
            direction = math.normalize(direction);
            
            quaternion targetRotation = quaternion.LookRotationSafe(direction, math.up());

            transform.Rotation = math.slerp(transform.Rotation, targetRotation, math.saturate(speed.Value * DeltaTime));
        }
    }
}