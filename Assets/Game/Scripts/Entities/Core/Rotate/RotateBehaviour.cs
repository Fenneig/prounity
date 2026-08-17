using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class RotateBehaviour : IEntityInit, IEntityFixedTick
    {
        private IRequest<Vector3> _rotateRequest;
        private ICommand<RotateArgs> _command;
        //private IFunction<Vector3, bool> _rotateCondition;
        //private IAction<Vector3, float> _rotateAction;
        //private IEvent<Vector3> _rotateEvent;

        public void Init(IEntity entity)
        {
            _rotateRequest = entity.GetRotateRequest();
            _command = entity.GetRotateCommand();
            //_rotateCondition = entity.GetRotateCondition();
            //_rotateAction = entity.GetRotateAction();
            //_rotateEvent = entity.GetRotateEvent();
        }

        public void FixedTick(IEntity entity, float deltaTime)
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