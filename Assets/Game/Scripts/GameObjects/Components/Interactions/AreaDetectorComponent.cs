using UnityEngine;

namespace Game
{
    public class AreaDetectorComponent : MonoBehaviour
    {
        [SerializeField] private Transform _detectOrigin;
        [SerializeField] private LayerMask _includedLayers;
        [SerializeField] private float _detectRadius;
        
        public Collider2D[] Detect() =>
            Physics2D.OverlapCircleAll(
                _detectOrigin.position,
                _detectRadius,
                _includedLayers
            );
    }
}