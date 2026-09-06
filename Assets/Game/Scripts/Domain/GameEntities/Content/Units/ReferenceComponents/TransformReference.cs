using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public struct TransformReference : IComponentData
    {
        public TransformHandle Value;
    }
}