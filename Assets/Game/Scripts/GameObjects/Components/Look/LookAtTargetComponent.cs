using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(FlipComponent))]
    public sealed class LookAtTargetComponent : MonoBehaviour
    {
        private FlipComponent _flipComponent;
        
        private Transform _target;

        private void Awake() => _flipComponent = GetComponent<FlipComponent>();
        
        public void SetTarget(Transform target) => _target = target;
        
        public void UnsetTarget() => _target = null;
        
        private void Update()
        {
            if (_target == null)
                return;
            
            _flipComponent.Flip(_target);
        }
    }
}