using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class BaseAuthoring : MonoBehaviour
    {
        private class Baker : Baker<BaseAuthoring> 
        {
            public override void Bake(BaseAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent<Base>(entity);
            }
        }
    }
}