using UnityEngine;

namespace Game.Entities
{
    public sealed class BulletViewInstaller : GameEntityInstaller
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        public override void Install(IGameEntity entity)
        {
            entity.AddTrailRender(_trailRenderer);

            entity.GetRespawnAction().Add(() => entity.GetTrailRender().Clear());
        }
    }
}