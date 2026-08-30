using Unity.Entities;
using Unity.Mathematics;

namespace Game.GameEntities.Core
{
    public struct RotateDirection : IComponentData
    {
        public float3 Value;
    }
}