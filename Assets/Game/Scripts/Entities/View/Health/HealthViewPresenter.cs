using Atomic.Elements;
using Atomic.Entities;
using Game.UI;

namespace Game.Entities
{
    public class HealthViewPresenter : IEntityInit, IEntityDispose
    {
        private readonly IGameUI _ui;

        private IValue<int> _maxHealth;
        private IReactiveVariable<int> _health;
        private StatView _healthView;
        private Subscription<int> _subscription;

        public HealthViewPresenter(IGameUI ui)
        {
            _ui = ui;
        }

        public void Init(IEntity entity)
        {
            _maxHealth = entity.GetMaxHealth();
            _health = entity.GetHealth();
            _healthView = _ui.GetHealthView();

            _subscription = _health.Observe(UpdateHealth);
        }

        public void Dispose(IEntity entity)
        {
            _subscription.Dispose();
        }

        private void UpdateHealth(int newValue)
        {
            _healthView.SetText(newValue.ToString());
            _healthView.SetProgress((float)newValue / _maxHealth.Value);
            _healthView.SetVisible(newValue > 0);
        }
    }
}