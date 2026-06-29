using Game.Views;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    [CreateAssetMenu(
        fileName = "PresentersInstallers",
        menuName = "Zenject/New PresentersInstallers"
    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlanetPopupPresenter>()
                .FromNew()
                .AsSingle();
            
            Container
                .BindFactory<Planet, PlanetView, PlanetPresenter, PlanetPresenter.Factory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlanetCollectionPresenter>()
                .FromNew()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<MoneyPresenter>()
                .FromNew()
                .AsSingle();
        }
    }
}