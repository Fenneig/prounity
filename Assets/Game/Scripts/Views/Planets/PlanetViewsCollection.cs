using System;
using System.Linq;
using UnityEngine;

namespace Game.Views
{
    public sealed class PlanetViewsCollection : MonoBehaviour
    {
        [Serializable]
        private struct Entry
        {
            public string Id;
            public PlanetView View;
        }
        
        [SerializeField] private Entry[] _entries;

        public PlanetView GetView(string id) => 
            _entries.First(entry => entry.Id == id).View;
    }
}