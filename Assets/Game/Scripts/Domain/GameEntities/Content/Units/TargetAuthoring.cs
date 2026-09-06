using Game.GameEntities.Core;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class TargetAuthoring : MonoBehaviour
    {
        [SerializeField] private float _searchTargetCooldown;
        
        private class Baker : Baker<TargetAuthoring>
        {
            public override void Bake(TargetAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new CombatTarget { Value = Entity.Null });

                AddComponent(entity, new IsInRangeWithTarget());
                SetComponentEnabled<IsInRangeWithTarget>(entity, false);
                
                AddComponent(entity, new SearchTargetRequest());
                SetComponentEnabled<SearchTargetRequest>(entity, true);            
                
                AddComponent(entity, new SearchTargetCooldown{ Duration = authoring._searchTargetCooldown, Remaining = 0f });
            }
        }
    }
}