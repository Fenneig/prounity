using Game.Common;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class UnitSpawnerAuthoring : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count;
        [SerializeField] private float _spacing;
        [SerializeField] private TeamType _teamType;
        
        private class Baker : Baker<UnitSpawnerAuthoring>
        {
            public override void Bake(UnitSpawnerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.None);

                Entity swordsmanPrefab = GetEntity(authoring._prefab, TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new UnitSpawner
                {
                    Prefab = swordsmanPrefab,
                    Count = authoring._count,
                    Spacing = authoring._spacing,
                    Team = authoring._teamType,
                    SpawnPosition = authoring.transform.position
                });
            }
        }
    }
}