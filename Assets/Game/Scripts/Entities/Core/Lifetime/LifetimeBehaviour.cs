using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public sealed class LifetimeBehaviour : IEntityInit, IEntityTick
    {
        private ICooldown _cooldown;
        private IAction _action;
        
        public void Init(IEntity entity)
        {
            _cooldown = entity.GetLifetime();
            _action = entity.GetDestroyAction();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            _cooldown.Tick(deltaTime);
            
            if (_cooldown.IsCompleted())
                _action?.Invoke();
        }
    }
}