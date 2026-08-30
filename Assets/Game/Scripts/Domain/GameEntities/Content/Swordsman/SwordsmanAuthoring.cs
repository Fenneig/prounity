using Game.GameEntities.Core;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class SwordsmanAuthoring : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private GameObject _target;
        
        public class SwordsmanBaker : Baker<SwordsmanAuthoring>
        {
            public override void Bake(SwordsmanAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                var targetEntity = GetEntity(authoring._target, TransformUsageFlags.Dynamic);
                
                AddComponent<Swordsman>(entity);
                AddComponent(entity, new MoveSpeed { Value = authoring._moveSpeed });
                AddComponent(entity, new MoveTarget { Value = targetEntity });
                AddComponent(entity, new RotateSpeed { Value = authoring._moveSpeed });
                AddComponent(entity, new RotateDirection { Value = new float3() });
                AddComponent(entity, new MoveDirection { Value = new float3() });
            }
        }
    }
}