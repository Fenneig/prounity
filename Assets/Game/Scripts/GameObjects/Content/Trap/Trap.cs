using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CollisionComponent))]
    [RequireComponent(typeof(TouchRequestComponent))]
    [RequireComponent(typeof(DestroyTouchDamage))]
    public class Trap : MonoBehaviour, TouchRequestComponent.IAction
    {
        private CollisionComponent _collisionComponent;
        private TouchRequestComponent _touchRequestComponent;
        private DestroyTouchDamage _destroyTouchDamage;
        
        private void Awake()
        {
            _collisionComponent = GetComponent<CollisionComponent>();
            _touchRequestComponent = GetComponent<TouchRequestComponent>();
            _destroyTouchDamage = GetComponent<DestroyTouchDamage>();

            _touchRequestComponent.SetAction(this);
        }
        
        private void OnEnable() => _collisionComponent.OnEntered += Touch;
        private void OnDisable() => _collisionComponent.OnEntered -= Touch;
        
        private void Touch(Collision2D target)
        {
            if (target.gameObject.name == name) 
                return;
            
            _touchRequestComponent.Touch(target);
        }
        
        public void Invoke(GameObject target)
        {
            if (target.gameObject.TryGetComponent(out HealthComponent healthComponent))
                _destroyTouchDamage.Damage(healthComponent);
        }
    }
}