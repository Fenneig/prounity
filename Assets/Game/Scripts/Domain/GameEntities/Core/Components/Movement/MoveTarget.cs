using Unity.Entities;

namespace Game.GameEntities.Core
{
    public struct MoveTarget : IComponentData
    {
        public Entity Value;
    }
}