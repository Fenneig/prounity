using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public class ZombieAiAttackBehaviour : IEntityInit, IEntityTick
    {
        private IVariable<float> _attackDistance;
        
        public void Init(IEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}