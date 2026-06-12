using Game.Systems;
using Game.Systems.Damage;
using Game.UI.Visual;
using Game.Utils;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Bullets
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Pool _bulletPool;
        [SerializeField] private TransformBounds _levelBounds;
        [SerializeField] private VfxPool _vfxPool;
        
        public void Spawn(Vector2 position, Vector2 direction, BulletConfig bulletConfig, TeamType team)
        {
            Bullet bullet = _bulletPool.Get().GetComponent<Bullet>();

            SetTransform(bullet, position, direction);
            
            bullet.Initialize(bulletConfig.Speed, _levelBounds);
            bullet.GetComponent<BulletVisual>().Initialize(bulletConfig, team, _vfxPool);
            bullet.GetComponent<DamageComponent>().Initialize(bulletConfig.Damage, team);
            
            bullet.SetLifeEndAction(_ => _bulletPool.Return(bullet.transform));
        }

        private void SetTransform(Bullet bullet, Vector2 position, Vector2 direction)
        {
            bullet.transform.position = position;
            bullet.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        }
    }
}