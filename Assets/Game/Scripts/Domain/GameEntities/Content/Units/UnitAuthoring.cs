using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class UnitAuthoring : MonoBehaviour
    {
        private class Baker : Baker<UnitAuthoring>
        {
            public override void Bake(UnitAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent(entity, new Unit());
            }
        }
    }
}