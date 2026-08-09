using System.IO;
using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class TargetObject : MonoBehaviour, ISerializableComponent
    {
        ///Variable
        [field: SerializeField]
        public Entity Value { get; set; }
        
        public void Serialize(ISaveSerializer serializer, BinaryWriter writer) =>
            serializer.Serialize(this, writer);
        
        public void Deserialize(ISaveSerializer serializer, BinaryReader reader) => 
            serializer.Deserialize(this, reader);
    }
}