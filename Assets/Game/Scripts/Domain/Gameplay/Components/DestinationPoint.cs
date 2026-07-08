using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class DestinationPoint : MonoBehaviour, ISaveSerializer<SerializedVector3>
    {
        ///Variable
        [field: SerializeField]
        public Vector3 Value { get; set; }
        
        public SerializedVector3 Serialize() => Value;
        
        public void Deserialize(SerializedVector3 value) => Value = value;
    }
}