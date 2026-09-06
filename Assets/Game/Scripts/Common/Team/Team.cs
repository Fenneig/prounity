using Unity.Entities;

namespace Game.Common
{
    public struct Team : IComponentData
    {
        public TeamType Value;
    }
}