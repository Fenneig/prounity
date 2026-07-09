using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Countdown : MonoBehaviour, ISaveSerializer
    {
        ///Variable
        [field: SerializeField]
        public float Current { get; set; }

        ///Const
        [field: SerializeField]
        public float Duration { get; private set; }

        public void Serialize(ref SaveWriter writer) => writer.Write(Current);
        public void Deserialize(ref SaveReader reader) => Current = reader.ReadFloat();
    }
}