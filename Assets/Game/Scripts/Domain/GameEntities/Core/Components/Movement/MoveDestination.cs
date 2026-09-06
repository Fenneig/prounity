using Unity.Entities;
using Unity.Mathematics;

namespace Game.GameEntities.Core
{
    public struct MoveDestination : IComponentData, IEnableableComponent
    {
        public float3 Value;
    }
}