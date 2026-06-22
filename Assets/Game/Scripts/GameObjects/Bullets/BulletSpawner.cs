using Game.GameObjects.Components;
using Game.Systems;
using Game.Utils;
using UnityEngine;

namespace Game.GameObjects.Bullets
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;
        
        public Bullet SpawnBullet(Vector2 position, Vector2 direction, BulletConfig config, TeamType team)
        {
            Bullet bullet = _bulletPool.Get();
            
            SetTransform(position, direction, bullet);
            
            bullet.GetComponent<MoveComponent>().Initialize(config.Speed);
            bullet.GetComponent<MoveComponent>().Direction = direction;
            bullet.GetComponent<BulletVisual>().Initialize(config, team);
            bullet.GetComponent<DamageComponent>().Initialize(config.Damage, team);
            
            bullet.OnDispose += ReturnToPool;
            return bullet;
        }

        private void ReturnToPool(Bullet bullet)
        {
            bullet.OnDispose -= ReturnToPool;
            _bulletPool.Return(bullet);
        }

        private void SetTransform(Vector2 position, Vector2 direction, Bullet bullet)
        {
            bullet.transform.position = position;
            bullet.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        }
    }
}