using Unity.Entities;

namespace Game.GameEntities.Core
{
    public struct SearchTargetCooldown : IComponentData
    {
        public float Duration;
        public float Remaining;
    }
}