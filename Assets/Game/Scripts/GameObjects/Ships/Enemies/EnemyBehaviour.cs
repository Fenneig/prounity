using Game.GameObjects.Components;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public sealed class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float _stoppingDistance = 0.25f;

        private Vector3 _fireDestination;
        private Transform _target;
        private WeaponComponent _weaponComponent;
        private MoveComponent _moveComponent;

        private bool IsReachedFireDistance => 
            Vector3.Distance(transform.position, _fireDestination) <= _stoppingDistance;

        public void Construct(Transform targetShip) => 
            _target = targetShip;

        private void Awake()
        {
            _weaponComponent = GetComponent<WeaponComponent>();
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void OnEnable() => 
            _weaponComponent.OnReload += Fire;

        private void OnDisable() => 
            _weaponComponent.OnReload -= Fire;

        private void Fire()
        {
            if (_target == null)
                return;
            
            if (IsReachedFireDistance)
                _weaponComponent.Fire((_target.position - transform.position).normalized);
        }

        private void LateUpdate()
        {
            if (IsReachedFireDistance) 
                _moveComponent.Direction = Vector2.zero;
        }
        
        public void Initialize(Vector2 destination)
        {
            _fireDestination = destination;
            _moveComponent.Direction = (_fireDestination - transform.position).normalized;
        }
    }
}