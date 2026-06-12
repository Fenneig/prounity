using UnityEngine;

namespace Game.GameObjects.Bullets
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Game resources/Configs/BulletConfig")]
    public sealed class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public GameObject ExplosionVFX { get; private set; }
    }
}