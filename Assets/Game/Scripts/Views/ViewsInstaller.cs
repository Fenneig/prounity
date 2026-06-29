using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private PlanetPopupView _planetPopup;
        [SerializeField] private PlanetViewsCollection _planetViewsCollection;
        [SerializeField] private MoneyView _moneyView;
        
        public override void InstallBindings()
        {
            Container
                .Bind<PlanetPopupView>()
                .FromInstance(_planetPopup)
                .AsSingle();

            Container
                .Bind<PlanetViewsCollection>()
                .FromInstance(_planetViewsCollection)
                .AsSingle();
            
            Container
                .Bind<MoneyView>()
                .FromInstance(_moneyView)
                .AsSingle();
        }
    }
}