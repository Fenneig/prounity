using Unity.Entities;

namespace Game.GameEntities.Core
{
    public enum AttackState : byte
    {
        Ready,
        Preparing,
        Cooldown,
        Attacking
    }
    
    public struct AttackStateComponent : IComponentData
    {
        public AttackState Value;
    }
}