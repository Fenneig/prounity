using Game.GameEntities.Core;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class HealthAuthoring : MonoBehaviour
    {
        [SerializeField] private float _health;
        
        private class Baker : Baker<HealthAuthoring>
        {
            public override void Bake(HealthAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new Health { Max = authoring._health, Current = authoring._health});
                AddComponent(entity, new IsTakeDamage());
                SetComponentEnabled<IsTakeDamage>(entity, false);
            }
        }
    }
}