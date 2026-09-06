using Unity.Entities;

namespace Game.GameEntities.Core
{
    public struct AttackAnticipation : IComponentData
    {
        public float Duration;
        public float Remaining;
    }
}