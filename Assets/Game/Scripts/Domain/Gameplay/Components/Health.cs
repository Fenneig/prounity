using System.IO;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Health : MonoBehaviour, ISerializableComponent
    {
        ///Variable
        [field: SerializeField]
        public int Current { get; set; } = 50;

        ///Const
        [field: SerializeField]
        public int Max { get; private set; } = 100;
        
        public void Serialize(ISaveSerializer serializer, BinaryWriter writer) =>
            serializer.Serialize(this, writer);
        
        public void Deserialize(ISaveSerializer serializer, BinaryReader reader) => 
            serializer.Deserialize(this, reader);
    }
}