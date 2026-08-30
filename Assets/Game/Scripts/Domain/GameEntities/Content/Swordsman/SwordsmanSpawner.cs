using Unity.Entities;

namespace Game.GameEntities.Content
{
    public struct SwordsmanSpawner : IComponentData
    {
        public Entity Prefab;
        public int Count;
        public float Spacing;
    }
}