using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private PlanetPopupView _planetPopup;
        [SerializeField] private PlanetView[] _views;
        [SerializeField] private MoneyView _moneyView;
        
        public override void InstallBindings()
        {
            Container
                .Bind<PlanetPopupView>()
                .FromInstance(_planetPopup)
                .AsSingle();

            foreach (var view in _views)
                Container
                    .Bind<PlanetView>()
                    .FromInstance(view)
                    .AsCached();
            
            Container
                .Bind<MoneyView>()
                .FromInstance(_moneyView)
                .AsSingle();
        }
    }
}