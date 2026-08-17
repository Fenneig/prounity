using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public class AttackSoundBehaviour : IEntityInit, IEntityTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IEntity entity)
        {
            _request = entity.GetAttackSoundRequest();
            _command = entity.GetAttackSoundCommand();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}