using Unity.Entities;

namespace Game.GameEntities.Core
{
    public struct Health : IComponentData
    {
        public float Max;
        public float Current;
    }
}