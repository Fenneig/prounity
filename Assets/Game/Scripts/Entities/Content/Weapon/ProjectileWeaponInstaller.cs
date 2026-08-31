using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class ProjectileWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private ReactiveVariable<int> _ammo;
        [SerializeField] private Transform _firePoint;
        
        public override void Install(IGameEntity entity)
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