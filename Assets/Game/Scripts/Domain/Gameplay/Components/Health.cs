using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Health : MonoBehaviour, ISaveSerializer<int>
    {
        ///Variable
        [field: SerializeField]
        public int Current { get; set; } = 50;

        ///Const
        [field: SerializeField]
        public int Max { get; private set; } = 100;
        
        public int Serialize() => Current;
        
        public void Deserialize(int value) => Current = value;
    }
}