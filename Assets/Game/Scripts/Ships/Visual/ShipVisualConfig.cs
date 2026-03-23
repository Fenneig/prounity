using UnityEngine;

namespace Game.Ships.Visual
{
    [CreateAssetMenu(menuName = "Game/ShipVisual", order = 0)]
    public sealed class ShipVisualConfig : ScriptableObject
    {
        [field: SerializeField] public Material MaterialPrefab { get; private set; }
        [field: Header("Move")]
        [field: SerializeField] public float MoveRotationAngle { get; private set; } = 30f;
        [field: Header("Damage")]
        [field: SerializeField] public AnimationCurve HitAnimationCurve { get; private set; }
        [field: SerializeField] public string HitPropertyName { get; private set; } = "_HitBlend";
        [field: SerializeField] public float HitDuration { get; private set; } = 0.2f;
        [field: Header("Destroy")]
        [field: SerializeField] public ParticleSystem DestroyEffectPrefab { get; private set; }
    }
}