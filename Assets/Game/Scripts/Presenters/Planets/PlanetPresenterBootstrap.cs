using Game.Views;
using Modules.Planets;
using Zenject;

namespace Game.Presenters
{
    public class PlanetPresenterBootstrap : IInitializable
    {
        private readonly PlanetProvider _planetProvider;
        private readonly PlanetView[] _planetViews;
        private readonly PlanetPresenter.Factory _factory; 

        public PlanetPresenterBootstrap(PlanetProvider planetProvider, PlanetView[] planetViews, PlanetPresenter.Factory factory)
        {
            _planetProvider = planetProvider;
            _planetViews = planetViews;
            _factory = factory;
        }

        public void Initialize()
        {
            foreach (var view in _planetViews)
            {
                Planet planet = _planetProvider.GetPlanet(view.PlanetConfig.Name);

                _factory.Create(planet, view);
            }
        }
    }
}