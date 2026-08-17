using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class ZombieAiMoveBehaviour : IEntityInit, IEntityFixedTick
    {
        private IVariable<IEntity> _target;
        private IRequest<Vector3> _moveRequest;
        
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
            _moveRequest = entity.GetMoveRequest();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            if (_target.Value != null)
                _moveRequest.Invoke(entity.GetNormalizedDirectionToTarget(_target.Value.GetPosition().Value));
        }
    }
}