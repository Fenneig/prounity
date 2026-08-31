using Atomic.Elements;

namespace Game.Entities
{
    public class AttackSoundBehaviour : IGameEntityInit, IGameEntityTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IGameEntity entity)
        {
            _request = entity.GetAttackSoundRequest();
            _command = entity.GetAttackSoundCommand();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}