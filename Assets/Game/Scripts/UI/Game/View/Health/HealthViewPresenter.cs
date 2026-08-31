using Atomic.Elements;
using Game.Entities;

namespace Game.UI
{
    public class HealthViewPresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameEntity _character;

        private IReactiveVariable<int> _health;
        private StatView _healthView;
        private Subscription<int> _subscription;
        private HealthScreenView _healthScreenView;

        public HealthViewPresenter(IGameContext context)
        {
            _character = context.GetCharacter();
        }

        public void Init(IGameUI entity)
        {
            _health = _character.GetHealth();
            _healthView = entity.GetHealthView();
            _healthScreenView = entity.GetHealthScreenView();
            
            _subscription = _health.Observe(UpdateHealth);
        }

        public void Dispose(IGameUI entity)
        {
            _subscription.Dispose();
        }

        private void UpdateHealth(int newValue)
        {
            _healthView.SetText(newValue.ToString());
            _healthView.SetProgress(_character.GetHealthPercent());
            _healthView.SetVisible(newValue > 0);
            
            _healthScreenView.ChangePercent(_character.GetHealthPercent());
        }
    }
}