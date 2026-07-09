using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Health : MonoBehaviour, ISaveSerializer
    {
        ///Variable
        [field: SerializeField]
        public int Current { get; set; } = 50;

        ///Const
        [field: SerializeField]
        public int Max { get; private set; } = 100;

        public void Serialize(ref SaveWriter writer) => writer.Write(Current);
        public void Deserialize(ref SaveReader reader) => Current = reader.ReadInt();
    }
}