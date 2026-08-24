using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WorldTransform : MonoBehaviour
    {
        public static Transform Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this.transform;
        }
    }
}