using Game.Common;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.GameEntities.Content
{
    public struct UnitSpawner : IComponentData
    {
        public Entity Prefab;
        public int Count;
        public float Spacing;
        public TeamType Team;
        public float3 SpawnPosition;
    }
}