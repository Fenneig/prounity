namespace Game.Entities
{
    public static class TargetUseCase
    {
        public static void TrySetTarget(this IGameEntity entity, IGameEntity target)
        {
            if (!entity.CanSetTarget(target))
                return;
            
            entity.GetTarget().Value = target;
        }

        public static void TryUnsetTarget(this IGameEntity entity, IGameEntity target)
        {
            if (!entity.IsHealthExists() || !entity.IsSameTarget(target))
                return;
            
            entity.GetTarget().Value = null;
        }

        public static bool HasValidTarget(this IGameEntity entity) 
        {
            entity.TryGetTarget(out var target);
            return target.Value != null && target.Value.IsHealthExists();
        }

        public static bool IsReachTarget(this IGameEntity entity, float range)
        {
            if (entity.GetTarget().Value == null)
                return false;

            var distanceToTarget = (entity.GetPosition().Value - entity.GetTarget().Value.GetPosition().Value).magnitude;
            return distanceToTarget < range;
        }

        private static bool CanSetTarget(this IGameEntity entity, IGameEntity target) => 
            entity.IsHealthExists() && 
            target != null && 
            target.HasCharacterTag() && 
            target.IsHealthExists();

        private static bool IsSameTarget(this IGameEntity entity, IGameEntity target)
        {
            var targetTransform = entity.GetTarget().Value;
            return targetTransform != null && targetTransform.InstanceID == target.InstanceID;
        }
    }
}