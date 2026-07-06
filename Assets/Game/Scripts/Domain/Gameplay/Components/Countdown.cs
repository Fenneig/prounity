using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class Countdown : MonoBehaviour, ISaveSerializer<float>
    {
        ///Variable
        [field: SerializeField]
        public float Current { get; set; }

        ///Const
        [field: SerializeField]
        public float Duration { get; private set; }
        
        public float Serialize() => Current;
        
        public void Deserialize(float value) => Current = value;
    }
}