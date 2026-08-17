using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class MeleeWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private Const<float> _attackRange;
        [SerializeField] private Transform _initPoint;
        [SerializeField] private Const<int> _damage;
        [SerializeField] private LayerMask _layerMask;
        
        
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            
            entity.GetFireCommand()
                .AddAction(() => entity.OverlapSplashDamage(_initPoint, _attackRange.Value, _damage.Value, _layerMask));
        }
    }
}