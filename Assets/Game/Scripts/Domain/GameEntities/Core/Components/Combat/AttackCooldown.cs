using Unity.Entities;

namespace Game.GameEntities.Core
{
    public struct AttackCooldown : IComponentData
    {
        public float Duration;
        public float Remaining;
    }
}