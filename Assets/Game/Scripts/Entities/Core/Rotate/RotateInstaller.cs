using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class RotateInstaller : IEntityInstaller
    {
        [SerializeField] private Const<float> _rotateSpeed;
        
        public void Install(IEntity entity)
        {
            entity.AddRotateRequest(new Request<Vector3>());
            entity.AddRotateCommand(new Command<RotateArgs>());
            entity.AddBehaviour(new RotateBehaviour());
            
            entity.AddRotationSpeed(_rotateSpeed);
        }
    }
}