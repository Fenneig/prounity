using System.Collections.Generic;
using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class ProductionOrder : MonoBehaviour, ISaveSerializer, IReferenceResolver
    {
        ///Variable
        [SerializeField] private List<EntityConfig> _queue;

        private List<string> _queueNames;

        public IReadOnlyList<EntityConfig> Queue
        {
            get { return _queue; }
            set { _queue = new List<EntityConfig>(value); }
        }

        public void Serialize(ref SaveWriter writer)
        {
            writer.Write(_queue.Count);

            for (int i = 0; i < _queue.Count; i++)
                writer.Write(_queue[i].Name);
        }

        public void Deserialize(ref SaveReader reader)
        {
            int count = reader.ReadInt();
            
            _queueNames = new List<string>(count);

            for (int i = 0; i < count; i++)
                _queueNames.Add(reader.ReadString());
        }

        public void Resolve(ResolveContext context)
        {
            foreach (var configName in _queueNames)
                if (context.EntityCatalog.FindConfig(configName, out EntityConfig config))
                    _queue.Add(config);
        }
    }
}