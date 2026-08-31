using Atomic.Elements;

namespace Game.Entities
{
    public class MeleeAttackBehaviour : IGameEntityInit, IGameEntityTick
    {
        private ICommand _fireCommand;

        public void Init(IGameEntity entity)
        {
            _fireCommand = entity.GetFireCommand();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (_fireCommand.CanInvoke() && !entity.GetWantsToFire().Value) 
                entity.GetWantsToFire().Value = true;
        }
    }
}