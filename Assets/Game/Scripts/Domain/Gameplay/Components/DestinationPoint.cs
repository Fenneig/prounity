using System.IO;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class DestinationPoint : MonoBehaviour, ISerializableComponent
    {
        ///Variable
        [field: SerializeField]
        public Vector3 Value { get; set; }
        
        public void Serialize(ISaveSerializer serializer, BinaryWriter writer) =>
            serializer.Serialize(this, writer);
        
        public void Deserialize(ISaveSerializer serializer, BinaryReader reader) => 
            serializer.Deserialize(this, reader);
    }
}