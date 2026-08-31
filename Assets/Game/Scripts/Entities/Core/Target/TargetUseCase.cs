namespace Game.Entities
{
    public static class TargetUseCase
    {
        public static void SetTarget(this IGameEntity entity, IGameEntity target)
        {
            if (!target.HasCharacterTag())
                return;
            
            entity.GetTarget().Value = target;
        }

        public static void UnsetTarget(this IGameEntity entity)
        {
            entity.GetTarget().Value = null;
        }

        public static bool IsSameTarget(this IGameEntity entity, IGameEntity target)
        {
            if (!target.HasCharacterTag())
                return false;
            
            var targetTransform = entity.GetTarget().Value;
            return targetTransform != null && targetTransform.InstanceID == target.InstanceID;
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
    }
}