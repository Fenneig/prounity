using System.Collections.Generic;
using Game.Views;
using Modules.Planets;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetCollectionPresenter : IInitializable
    {
        private readonly PlanetViewsCollection _planetViewsCollection;
        private readonly PlanetPresenter.Factory _factory;
        private readonly List<Planet> _planets;
        
        public PlanetCollectionPresenter(PlanetViewsCollection planetViewsCollection, List<Planet> planets, PlanetPresenter.Factory factory)
        {
            _planetViewsCollection = planetViewsCollection;
            _planets = planets;
            _factory = factory;
        }

        public void Initialize()
        {
            foreach (var planet in _planets) 
                _factory.Create(planet, _planetViewsCollection.GetView(planet.Name));
        }
    }
}