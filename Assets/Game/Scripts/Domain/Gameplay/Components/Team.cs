using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Team : MonoBehaviour, ISaveSerializer
    {
        ///Variable
        [field: SerializeField]
        public TeamType Type { get; set; }

        public void Serialize(ref SaveWriter writer) => writer.Write((int)Type);

        public void Deserialize(ref SaveReader reader) => Type = (TeamType)reader.ReadInt();
    }
}