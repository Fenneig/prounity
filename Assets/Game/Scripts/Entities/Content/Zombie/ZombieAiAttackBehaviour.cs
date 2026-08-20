using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public class ZombieAiAttackBehaviour : IEntityInit, IEntityTick, IEntityDispose
    {
        private IEntity _self;
        private ICommand _fireCommand;
        private IValue<AnimationEvents> _animationEvents;

        public void Init(IEntity entity)
        {
            _self = entity;
            _fireCommand = entity.GetFireCommand();
            _animationEvents = entity.GetAnimationEvents();

            _animationEvents.Value.OnEvent += HandleAnimationEvent;
        }

        private void HandleAnimationEvent(string animationName)
        {
            if (animationName == "Attack")
            {
                _fireCommand.Invoke();
                _self.GetWantsToFire().Value = false;
            }
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            if (_fireCommand.CanInvoke() && !entity.GetWantsToFire().Value) 
                entity.GetWantsToFire().Value = true;
        }

        public void Dispose(IEntity entity)
        {
            _animationEvents.Value.OnEvent -= HandleAnimationEvent;
        }
    }
}