using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class TransformInstaller : IGameEntityInstaller
    {
        [SerializeField] private Transform _transform;
        
        public void Install(IGameEntity entity)
        {
            entity.AddPosition(new TransformPositionVariable(_transform));
            entity.AddRotation(new TransformRotationVariable(_transform));
        }
    }
}