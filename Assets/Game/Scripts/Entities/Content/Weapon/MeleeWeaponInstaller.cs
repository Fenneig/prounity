using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public sealed class MeleeWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private Const<float> _attackRange;
        [SerializeField] private Transform _initPoint;
        [SerializeField] private Const<int> _damage;
        [SerializeField] private LayerMask _layerMask;
        
        public override void Install(IGameEntity entity)
        {
            base.Install(entity);
            
            entity.GetFireCommand()
                .AddCondition(() =>
                {
                    entity.TryGetOwner(out var owner);
                    return owner?.Value != null && owner.Value.IsReachTarget(_attackRange);
                })
                .AddAction(() => entity.OverlapSplashDamage(_initPoint, _attackRange.Value, _damage.Value, _layerMask));
        }
    }
}