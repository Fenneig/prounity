using Atomic.Elements;

namespace Game.Entities
{
    public class ShoutSoundBehaviour : IGameEntityInit, IGameEntityTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IGameEntity entity)
        {
            _request = entity.GetShoutSoundRequest();
            _command = entity.GetShoutSoundCommand();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}