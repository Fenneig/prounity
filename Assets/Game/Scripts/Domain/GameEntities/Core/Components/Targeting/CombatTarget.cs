using Unity.Entities;

namespace Game.GameEntities.Core
{
    public struct CombatTarget : IComponentData
    {
        public Entity Value;
    }
}