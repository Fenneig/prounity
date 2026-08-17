using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    public class AnticipationBehaviour : IEntityInit, IEntityDispose
    {
        private ICooldown _anticipationCooldown;
        private IReactiveVariable<bool> _wantsToFire;
        
        public void Init(IEntity entity)
        {
            _anticipationCooldown = entity.GetFireAnticipation();
            _wantsToFire = entity.GetWantsToFire();
            
            _wantsToFire.OnEvent += OnWantToFireChanged;
        }

        public void Dispose(IEntity entity)
        {
            _wantsToFire.OnEvent -= OnWantToFireChanged;
        }

        private void OnWantToFireChanged(bool isWant)
        {
            if (isWant)
                _anticipationCooldown.ResetTime();
        }
    }
}