using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class ProjectileWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private ReactiveVariable<int> _ammo;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private SceneEntity _bulletPrefab;
        
        public override void Install(IEntity entity)
        {
            base.Install(entity);

            entity.GetFireCommand()
                .AddCondition(() => entity.GetAmmo().Value > 0)
                .AddAction(() => GameContext.Instance.SpawnBullet(_firePoint.position, _firePoint.rotation, entity.GetOwner().Value))
                .AddAction(() => entity.GetAmmo().Value--);
                
            entity.AddAmmo(_ammo);
        }
    }
}