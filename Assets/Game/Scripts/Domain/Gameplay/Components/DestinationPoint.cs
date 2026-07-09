using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class DestinationPoint : MonoBehaviour, ISaveSerializer
    {
        ///Variable
        [field: SerializeField]
        public Vector3 Value { get; set; }

        public void Serialize(ref SaveWriter writer) => writer.Write(Value);
        public void Deserialize(ref SaveReader reader) => Value = reader.ReadVector3();
    }
}