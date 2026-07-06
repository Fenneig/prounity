using System.Collections.Generic;
using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class ProductionOrder : MonoBehaviour, ISaveSerializer<string[]>, IReferenceResolver
    {
        ///Variable
        [SerializeField]
        private List<EntityConfig> _queue;

        private List<string> _queueNames;
        
        public IReadOnlyList<EntityConfig> Queue
        {
            get { return _queue; }
            set { _queue = new List<EntityConfig>(value); }
        }

        public string[] Serialize()
        {
            string[] data = new string[_queue.Count];
            
            for (int i = 0; i < _queue.Count; i++)
                data[i] = _queue[i].Name;
            
            return data;
        }

        public void Deserialize(string[] value) => _queueNames = new List<string>(value);

        public void Resolve(ResolveContext context)
        {
            foreach (var configName in _queueNames)
                if (context.EntityCatalog.FindConfig(configName, out EntityConfig config))
                    _queue.Add(config);
        }
    }
}