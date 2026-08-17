using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public class BodyFallSoundBehaviour : IEntityInit, IEntityTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IEntity entity)
        {
            _request = entity.GetBodyFallSoundRequest();
            _command = entity.GetBodyFallSoundCommand();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}