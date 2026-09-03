using Atomic.Elements;
using Game.Entities;

namespace Game.UI
{
    public class AmmoPresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameEntity _weapon;

        private IReactiveValue<int> _ammo;
        private StatView _ammoView;
        private Subscription<int> _subscription;


        public AmmoPresenter(IGameContext context)
        {
            _weapon = context.GetCharacter().GetWeapon().Value;
        }

        public void Init(IGameUI entity)
        {
            _ammo = _weapon.GetAmmo();
            _ammoView = entity.GetAmmoView();
            
            _subscription = _ammo.Observe(UpdateAmmo);
        }

        public void Dispose(IGameUI entity)
        {
            _subscription.Dispose();
        }

        private void UpdateAmmo(int newValue)
        {
            _ammoView.SetText(newValue.ToString());
        }
    }
}