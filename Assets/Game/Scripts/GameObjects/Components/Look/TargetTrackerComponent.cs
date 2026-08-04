using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(LookComponent))]
    public class TargetTrackerComponent : MonoBehaviour
    {
        private LookComponent _lookComponent;
        
        private Transform _target;

        private void Awake()
        {
            _lookComponent = GetComponent<LookComponent>();
        }
        
        public void SetTarget(Transform target) => _target = target;
        public void UnsetTarget() => _target = null;
        
        private void Update()
        {
            if (_target == null)
                return;
            
            _lookComponent.Look(_target);
        }
    }
}