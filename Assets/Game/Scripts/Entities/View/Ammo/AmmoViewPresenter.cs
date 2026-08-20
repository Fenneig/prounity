using Atomic.Elements;
using Atomic.Entities;
using Game.UI;

namespace Game.Entities
{
    public class AmmoViewPresenter : IEntityInit, IEntityDispose
    {
        private readonly IGameUI _ui;

        private IReactiveValue<int> _ammo;
        private StatView _ammoView;
        private Subscription<int> _subscription;


        public AmmoViewPresenter(IGameUI ui)
        {
            _ui = ui;
        }

        public void Init(IEntity entity)
        {
            _ammo = entity.GetAmmo();
            _ammoView = _ui.GetAmmoView();
            
            _subscription = _ammo.Observe(UpdateAmmo);
        }

        public void Dispose(IEntity entity)
        {
            _subscription.Dispose();
        }

        private void UpdateAmmo(int newValue)
        {
            _ammoView.SetText(newValue.ToString());
        }
    }
}