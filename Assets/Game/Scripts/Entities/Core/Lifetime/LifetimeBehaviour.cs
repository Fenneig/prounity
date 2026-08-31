using Atomic.Elements;

namespace Game.Entities
{
    public sealed class LifetimeBehaviour : IGameEntityInit, IGameEntityTick
    {
        private ICooldown _cooldown;
        private IAction _action;
        
        public void Init(IGameEntity entity)
        {
            _cooldown = entity.GetLifetime();
            _action = entity.GetDestroyAction();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            _cooldown.Tick(deltaTime);
            
            if (_cooldown.IsCompleted())
                _action?.Invoke();
        }
    }
}