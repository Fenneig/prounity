using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public sealed class FireBehaviour : IEntityInit, IEntityFixedTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IEntity entity)
        {
            _request = entity.GetFireRequest();
            _command = entity.GetFireCommand();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            if (_request.Consume() && _command.CanInvoke()) 
                _command.Invoke();
        }
    }
}