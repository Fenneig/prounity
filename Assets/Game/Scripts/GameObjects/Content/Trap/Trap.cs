using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CollisionComponent))]
    [RequireComponent(typeof(TouchRequestComponent))]
    public sealed class Trap : MonoBehaviour, TouchRequestComponent.IAction
    {
        private CollisionComponent _collisionComponent;
        private TouchRequestComponent _touchRequestComponent;
        private DealDamageComponent _dealDamageComponent;
        
        private void Awake()
        {
            _collisionComponent = GetComponent<CollisionComponent>();
            _touchRequestComponent = GetComponent<TouchRequestComponent>();
            _dealDamageComponent = GetComponent<DealDamageComponent>();

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
            if (_dealDamageComponent.TryDealDamage(target))
                Destroy(gameObject);
        }
    }
}