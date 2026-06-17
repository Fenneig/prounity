using Game.GameObjects.Components;
using UnityEngine;

namespace Game.GameObjects.Ships.Enemies
{
    public sealed class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private Ship _self;
        [SerializeField] private float _stoppingDistance = 0.25f;

        private Vector3 _fireDestination;
        private Transform _target;
        private WeaponComponent _weaponComponent;
        private MoveComponent _moveComponent;
        private Vector2 _moveDirection;

        private bool IsReachedFireDistance => 
            Vector3.Dot(_fireDestination - transform.position, _moveDirection) <= _stoppingDistance;
        
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
                _self.Fire((_target.position - transform.position).normalized);
        }

        private void Update()
        {
            if (!IsReachedFireDistance) 
                MoveToFireDistance();
        }

        private void MoveToFireDistance() => 
            _moveComponent.Move(_moveDirection);

        public void Initialize(Vector2 destination)
        {
            _fireDestination = destination;
            _moveDirection = (_fireDestination - transform.position).normalized;
        }
    }
}