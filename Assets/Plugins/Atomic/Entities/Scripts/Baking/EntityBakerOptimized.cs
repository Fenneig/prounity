namespace Atomic.Entities
{
    public abstract class EntityBakerOptimized<TArgs> : EntityBakerOptimized<string, IEntity, EntityView, TArgs> 
        where TArgs : IArgs
    {
    }
}