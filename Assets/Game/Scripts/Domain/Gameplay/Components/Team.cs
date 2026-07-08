using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Team : MonoBehaviour, ISaveSerializer<int>
    {
        ///Variable
        [field: SerializeField]
        public TeamType Type { get; set; }

        public int Serialize() => (int)Type;
        
        public void Deserialize(int value) => Type = (TeamType)value;
    }
}