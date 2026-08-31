using Atomic.Elements;

namespace Game.Entities
{
    public class AnticipationBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private ICooldown _anticipationCooldown;
        private IReactiveVariable<bool> _wantsToFire;
        
        public void Init(IGameEntity entity)
        {
            _anticipationCooldown = entity.GetFireAnticipation();
            _wantsToFire = entity.GetWantsToFire();
            
            _wantsToFire.OnEvent += OnWantToFireChanged;
        }

        public void Dispose(IGameEntity entity)
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