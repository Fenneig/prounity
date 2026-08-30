using Unity.Entities;

namespace Game.Common
{
    public struct TeamComponent : IComponentData
    {
        public TeamType Value;
    }
}