using Game.GameEntities.Core;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class AnimationAuthoring : MonoBehaviour
    {
        private class Baker : Baker<AnimationAuthoring>
        {
            public override void Bake(AnimationAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new AttackAnimationRequest());
                SetComponentEnabled<AttackAnimationRequest>(entity, false);
            }
        }
    }
}