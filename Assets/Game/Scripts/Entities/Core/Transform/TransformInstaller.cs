using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class TransformInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _transform;
        
        public void Install(IEntity entity)
        {
            entity.AddPosition(new TransformPositionVariable(_transform));
            entity.AddRotation(new TransformRotationVariable(_transform));
        }
    }
}