using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class BulletViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        public override void Install(IEntity entity)
        {
            entity.AddTrailRender(_trailRenderer);

            entity.GetRespawnAction().Add(() => entity.GetTrailRender().Clear());
        }
    }
}