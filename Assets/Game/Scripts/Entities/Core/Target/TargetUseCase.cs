using Atomic.Entities;

namespace Game.Entities
{
    public static class TargetUseCase
    {
        public static void SetTarget(this IEntity entity, IEntity target)
        {
            if (!target.HasCharacterTag())
                return;
            
            entity.GetTarget().Value = target;
        }

        public static void UnsetTarget(this IEntity entity)
        {
            entity.GetTarget().Value = null;
        }

        public static bool IsSameTarget(this IEntity entity, IEntity target)
        {
            if (!target.HasCharacterTag())
                return false;
            
            var targetTransform = entity.GetTarget().Value;
            return targetTransform != null && targetTransform.InstanceID == target.InstanceID;
        }
    }
}