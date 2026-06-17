using Game.UI.Visual;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Bullets
{
    public sealed class BulletFactory : Factory<Bullet>
    {
        [SerializeField] private TransformBounds _levelBounds;
        [SerializeField] private VfxPool _vfxPool;

        protected override void OnCreate(Bullet bullet)
        {
            base.OnCreate(bullet);
            
            bullet.Construct(_levelBounds);
            bullet.GetComponent<BulletVisual>().Construct(_vfxPool);
        }
    }
}