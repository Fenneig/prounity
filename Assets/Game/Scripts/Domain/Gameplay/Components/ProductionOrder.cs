using System.Collections.Generic;
using System.IO;
using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class ProductionOrder : MonoBehaviour, ISerializableComponent
    {
        ///Variable
        [SerializeField] private List<EntityConfig> _queue;
        
        public IReadOnlyList<EntityConfig> Queue
        {
            get { return _queue; }
            set { _queue = new List<EntityConfig>(value); }
        }
        
        public void Serialize(ISaveSerializer serializer, BinaryWriter writer) =>
            serializer.Serialize(this, writer);
        
        public void Deserialize(ISaveSerializer serializer, BinaryReader reader) => 
            serializer.Deserialize(this, reader);
    }
}