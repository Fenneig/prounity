using Atomic.Elements;

namespace Game.Entities
{
    public class BodyFallSoundBehaviour : IGameEntityInit, IGameEntityTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IGameEntity entity)
        {
            _request = entity.GetBodyFallSoundRequest();
            _command = entity.GetBodyFallSoundCommand();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}