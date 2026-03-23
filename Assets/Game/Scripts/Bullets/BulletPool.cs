using System.Collections.Generic;
using Game.Utils;
using Game.Visual;
using Modules.Utils;
using UnityEngine;

namespace Game.Bullets
{
    public sealed class BulletPool : MonoBehaviour
    {
        [SerializeField] private int _preloadCount = 10;
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private TransformBounds _levelBounds;
        
        private readonly Stack<Bullet> _pool = new();
        private VfxPool _vfxPool;
        
        public void Construct(VfxPool vfxPool) => 
            _vfxPool = vfxPool;

        public Bullet Spawn(Vector2 position, Vector2 direction, BulletConfig bulletConfig, TeamType team)
        {
            if (_pool.TryPop(out Bullet bullet))
                bullet.gameObject.SetActive(true);
            else
                bullet = BuiltBullet();

            ComposeBullet(position, direction, bulletConfig, bullet, team);

            return bullet;
        }

        private Bullet BuiltBullet()
        {
            var bullet = Instantiate(_bulletPrefab, _container);
            bullet.Construct(_levelBounds, _vfxPool);
            return bullet;
        }

        private void ComposeBullet(Vector2 position, Vector2 direction, BulletConfig bulletConfig, Bullet bullet, TeamType team)
        {
            bullet.Initialize(bulletConfig, team);

            bullet.SetLifeEndAction(Return);

            bullet.SetTransform(position, direction);
        }

        private void Return(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            
            _pool.Push(bullet);
        }

        private void Awake()
        {
            for (int i = 0; i < _preloadCount; i++)
            {
                var bullet = BuiltBullet();
                bullet.gameObject.SetActive(false);
                _pool.Push(bullet);
            }
        }
    }
}