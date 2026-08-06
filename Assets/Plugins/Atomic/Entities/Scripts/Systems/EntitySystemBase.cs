namespace Atomic.Entities
{
    public abstract class EntitySystemBase<TContext, TEntity> :
        IEntityInit<TContext>,
        IEntityDispose<TContext>,
        IEntityEnable<TContext>,
        IEntityDisable<TContext>
        where TContext : IEntity
        where TEntity : IEntity
    {

        private protected IReadOnlyEntityCollection<TEntity> _entities;

        protected abstract IReadOnlyEntityCollection<TEntity> ProvideEntityCollection(TContext context);
        
        public virtual void Init(TContext context)
        {
            _entities = this.ProvideEntityCollection(context);
        }

        public virtual void Dispose(TContext entity)
        {
            _entities = null;
        }

        public virtual void Enable(TContext context)
        {
            foreach (TEntity entity in _entities)
                this.OnEntityAdded(entity);

            _entities.OnAdded += this.OnEntityAdded;
            _entities.OnRemoved += this.OnEntityRemoved;
        }

        public virtual void Disable(TContext context)
        {
            _entities.OnAdded -= this.OnEntityAdded;
            _entities.OnRemoved -= this.OnEntityRemoved;

            foreach (TEntity entity in _entities)
                this.OnEntityRemoved(entity);
        }

        protected abstract void OnEntityAdded(TEntity entity);

        protected abstract void OnEntityRemoved(TEntity entity);
    }
}