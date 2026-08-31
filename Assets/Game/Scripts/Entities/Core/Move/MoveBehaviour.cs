using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class MoveBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest<Vector3> _moveRequest;
        private ICommand<MoveArgs> _moveCommand;
        private IVariable<float> _moveTime;
        
        public void Init(IGameEntity entity)
        {
            _moveRequest = entity.GetMoveRequest();
            _moveCommand = entity.GetMoveCommand();
            _moveTime = entity.GetMoveTime();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_moveRequest.Consume(out Vector3 moveDirection) && 
                moveDirection != Vector3.zero && 
                _moveCommand.CanInvoke(new MoveArgs(moveDirection, deltaTime)))
            {
                _moveCommand.Invoke(new MoveArgs(moveDirection, deltaTime));
                _moveTime.Value = Time.time;
            }
        }
    }
}