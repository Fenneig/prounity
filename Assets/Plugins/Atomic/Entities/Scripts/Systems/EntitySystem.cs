using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using Unity.Profiling;

namespace Atomic.Entities
{
    public abstract class EntitySystem<TContext, TEntity> : EntitySystemBase<TContext, TEntity>
        where TContext : IEntity
        where TEntity : IEntity
    {
        private EntityUpdater<TEntity> _updater;

#if ENABLE_PROFILER
        private ProfilerMarker _marker;
#endif
        protected EntitySystem()
        {
            _marker = new ProfilerMarker(this.GetType().Name + ".Update");
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sealed override void Init(TContext context)
        {
            base.Init(context);
            _updater = new EntityUpdater<TEntity>(this.ProvideUpdateSettings(context), this.Update, _entities.Count);
            this.OnInit(context);
        }

        protected abstract EntityUpdateSettings ProvideUpdateSettings(TContext context);
           
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnInit(TContext context)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sealed override void Enable(TContext context)
        {
            base.Enable(context);
            this.OnEnable(context);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnEnable(TContext context)
        {
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sealed override void Disable(TContext context)
        {
            this.OnDisable(context);
            base.Disable(context);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnDisable(TContext context)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sealed override void Dispose(TContext context)
        {
            this.OnDispose(context);
            _updater.Dispose();
            base.Dispose(context);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnDispose(TContext context)
        {
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private protected void Update(float deltaTime)
        {
#if ENABLE_PROFILER
            using (_marker.Auto())
#endif
                _updater.Update(deltaTime);
        }

        protected abstract void Update(TEntity entity, float deltaTime);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void OnEntityAdded(TEntity entity) => _updater.Add(entity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void OnEntityRemoved(TEntity entity) => _updater.Remove(entity);
        
        #region Debug

        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int entityCount => _updater?._entityCount ?? -1;

        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int batchSize => _updater?._batchSize ?? -1;

        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private TEntity[] entities => _updater?._entities;

        #endregion
    }

    public abstract class TickEntitySystem<TContext, TEntity> : EntitySystem<TContext, TEntity>, IEntityTick<TContext>
        where TContext : IEntity where TEntity : IEntity
    {
        public virtual void Tick(TContext entity, float deltaTime) => this.Update(deltaTime);
    }

    public abstract class FixedTickEntitySystem<TContext, TEntity>
        : EntitySystem<TContext, TEntity>, IEntityFixedTick<TContext>
        where TContext : IEntity
        where TEntity : IEntity
    {
        public virtual void FixedTick(TContext entity, float fixedDeltaTime) => this.Update(fixedDeltaTime);
    }

    public abstract class LateTickEntitySystem<TContext, TEntity>
        : EntitySystem<TContext, TEntity>, IEntityLateTick<TContext>
        where TContext : IEntity
        where TEntity : IEntity
    {
        public virtual void LateTick(TContext entity, float deltaTime) => this.Update(deltaTime);
    }
}