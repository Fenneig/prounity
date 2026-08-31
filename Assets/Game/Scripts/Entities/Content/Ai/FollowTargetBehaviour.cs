using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public class FollowTargetBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IVariable<IGameEntity> _target;
        private IRequest<Vector3> _moveRequest;
        
        public void Init(IGameEntity entity)
        {
            _target = entity.GetTarget();
            _moveRequest = entity.GetMoveRequest();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_target.Value != null)
                _moveRequest.Invoke(entity.GetNormalizedDirectionToTarget(_target.Value.GetPosition().Value));
        }
    }
}