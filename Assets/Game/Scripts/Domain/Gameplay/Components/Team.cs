using System.IO;
using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Team : MonoBehaviour, ISerializableComponent
    {
        ///Variable
        [field: SerializeField]
        public TeamType Type { get; set; }
        
        public void Serialize(ISaveSerializer serializer, BinaryWriter writer) =>
            serializer.Serialize(this, writer);
        
        public void Deserialize(ISaveSerializer serializer, BinaryReader reader) => 
            serializer.Deserialize(this, reader);
    }
}