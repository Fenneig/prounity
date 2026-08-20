using Atomic.Elements;
using Atomic.Entities;
using Game.UI;

namespace Game.Entities
{
    public class HealthViewPresenter : IEntityInit, IEntityDispose
    {
        private readonly IGameUI _ui;

        private IEntity _self;
        private IReactiveVariable<int> _health;
        private StatView _healthView;
        private Subscription<int> _subscription;
        private HealthScreenView _healthScreenView;

        public HealthViewPresenter(IGameUI ui)
        {
            _ui = ui;
        }

        public void Init(IEntity entity)
        {
            _self = entity;
            _health = entity.GetHealth();
            _healthView = _ui.GetHealthView();
            _healthScreenView = _ui.GetHealthScreenView();
            
            _subscription = _health.Observe(UpdateHealth);
        }

        public void Dispose(IEntity entity)
        {
            _subscription.Dispose();
        }

        private void UpdateHealth(int newValue)
        {
            _healthView.SetText(newValue.ToString());
            _healthView.SetProgress(_self.GetHealthPercent());
            _healthView.SetVisible(newValue > 0);
            
            _healthScreenView.ChangePercent(_self.GetHealthPercent());
        }
    }
}