using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class SwordsmanSpawnerAuthoring : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count;
        [SerializeField] private float _spacing;
        
        private class Baker : Baker<SwordsmanSpawnerAuthoring>
        {
            public override void Bake(SwordsmanSpawnerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.None);

                Entity swordsmanPrefab = GetEntity(authoring._prefab, TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new SwordsmanSpawner
                {
                    Prefab = swordsmanPrefab,
                    Count = authoring._count,
                    Spacing = authoring._spacing
                });
            }
        }
    }
}