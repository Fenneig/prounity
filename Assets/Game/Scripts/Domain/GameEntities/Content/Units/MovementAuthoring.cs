using Game.GameEntities.Core;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class MovementAuthoring : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        
        private class Baker : Baker<MovementAuthoring>
        {
            public override void Bake(MovementAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new MoveSpeed { Value = authoring._moveSpeed });
                AddComponent(entity, new MoveDestination { Value = new float3() });
                AddComponent(entity, new RotateSpeed { Value = authoring._rotateSpeed });
                AddComponent(entity, new RotateDirection { Value =  new float3() });
                
                AddComponent(entity, new MoveTarget { Value = Entity.Null });
            }
        }
    }
}