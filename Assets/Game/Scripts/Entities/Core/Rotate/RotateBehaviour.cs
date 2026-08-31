using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class RotateBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest<Vector3> _rotateRequest;
        private ICommand<RotateArgs> _command;

        public void Init(IGameEntity entity)
        {
            _rotateRequest = entity.GetRotateRequest();
            _command = entity.GetRotateCommand();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_rotateRequest.Consume(out Vector3 rotateDirection) &&
                rotateDirection != Vector3.zero &&
                _command.CanInvoke(new RotateArgs(rotateDirection, deltaTime)))
            {
                _command.Invoke(new RotateArgs(rotateDirection, deltaTime));
            }
        }
    }
}