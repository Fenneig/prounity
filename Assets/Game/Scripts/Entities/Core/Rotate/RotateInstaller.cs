using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public sealed class RotateInstaller : IGameEntityInstaller
    {
        [SerializeField] private Const<float> _rotateSpeed;
        
        public void Install(IGameEntity entity)
        {
            entity.AddRotateRequest(new Request<Vector3>());
            entity.AddRotateCommand(new Command<RotateArgs>());
            entity.AddBehaviour(new RotateBehaviour());
            
            entity.AddRotationSpeed(_rotateSpeed);
        }
    }
}