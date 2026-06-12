using UnityEngine;

namespace Game.GameObjects.Ships.Enemies
{
    public sealed class EnemyShip : AbstractShip
    {
        [SerializeField] private EnemyFireDistanceChecker _enemyFireDistanceChecker;
        private Transform _target;
        
        public void SetTarget(Transform targetShip) => 
            _target = targetShip;

        private void Awake()
        {
            _enemyFireDistanceChecker.OnReachFireDistance += WeaponComponent.AllowFire;
            WeaponComponent.OnReload += Fire;
        }

        private void Update()
        {
            if (!_enemyFireDistanceChecker.IsReachFireDistance)
                SetMoveDirection(_enemyFireDistanceChecker.GetMoveDirection());
        }

        private void Fire()
        {
            if (_target == null) 
                return;
            
            Vector2 direction = (_target.position - transform.position).normalized;
            WeaponComponent.Fire(direction);
        }

        private void OnDestroy()
        {
            _enemyFireDistanceChecker.OnReachFireDistance -= WeaponComponent.AllowFire;
            WeaponComponent.OnReload -= Fire;
        }
    }
}