using Unity.Entities;
using Unity.Mathematics;

namespace Game.GameEntities.Core
{
    public struct MoveDirection : IComponentData
    {
        public float3 Value;
    }
}