using System.IO;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Countdown : MonoBehaviour, ISerializableComponent
    {
        ///Variable
        [field: SerializeField]
        public float Current { get; set; }

        ///Const
        [field: SerializeField]
        public float Duration { get; private set; }
        
        public void Serialize(ISaveSerializer serializer, BinaryWriter writer) =>
            serializer.Serialize(this, writer);
        
        public void Deserialize(ISaveSerializer serializer, BinaryReader reader) => 
            serializer.Deserialize(this, reader);
    }
}