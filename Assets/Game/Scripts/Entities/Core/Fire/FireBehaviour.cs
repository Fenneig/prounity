using Atomic.Elements;

namespace Game.Entities
{
    public sealed class FireBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IGameEntity entity)
        {
            _request = entity.GetFireRequest();
            _command = entity.GetFireCommand();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume() && _command.CanInvoke()) 
                _command.Invoke();
        }
    }
}