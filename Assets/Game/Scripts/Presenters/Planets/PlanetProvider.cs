using System.Collections.Generic;
using System.Linq;
using Modules.Planets;

namespace Game.Presenters
{
    public class PlanetProvider
    {
        private Dictionary<string, Planet> _planets;

        public PlanetProvider(List<Planet> planets)
        {
            _planets = planets.ToDictionary(
                planet => planet.Name,
                planet => planet);
        }
        
        public Planet GetPlanet(string name) => _planets[name];
    }
}