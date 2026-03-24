using Game.Bullets;
using Game.Visual;
using UnityEngine;

namespace Game.Ships.Enemies
{
    public sealed class EnemyShip : AbstractShip
    {
        [SerializeField] private float _stoppingDistance = 0.25f;

        private Vector3 _fireDestination;
        private bool _isReachFireDistance;
        private Transform _target;
        private Vector3 _moveDirectionNormalized;
        
        public void Construct(ShipConfig config, BulletPool bulletPool, VfxPool vfxPool, Transform targetShip) 
        {
            base.Construct(config, bulletPool, vfxPool);
            _target = targetShip;
        }

        public void Initialize(Vector2 startPoint, Vector2 destination)
        {
            base.Initialize(startPoint);

            _isReachFireDistance = false;
            _fireDestination = destination;
            _moveDirectionNormalized = (_fireDestination - transform.position).normalized;
        }

        protected override Vector3 GetMoveDirection()
        { 
            if (_isReachFireDistance)
                return Vector3.zero;
            
            Vector3 position = transform.position;
            Vector2 distance = _fireDestination - position;

            bool isReached = Vector3.Dot(distance, _moveDirectionNormalized) <= 0;
            
            if (isReached)
            {
                _isReachFireDistance = true;
                FireCooldown.Reset();
                return Vector3.zero;
            }

            return _moveDirectionNormalized;
        }

        private void Fire()
        {
            if (_target == null || !_isReachFireDistance)
                return;
            
            Vector2 direction = _target.position - FirePoint;
            Fire(direction);
            FireCooldown.Reset();
        }

        private void Awake()
        {
            FireCooldown.OnFinished += Fire;
        }

        private void OnDestroy()
        {
            FireCooldown.OnFinished -= Fire;
        }
    }
}