using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using Unity.Profiling;

namespace Atomic.Entities
{
    public abstract class PriorityEntitySystem<TContext, TEntity> : EntitySystemBase<TContext, TEntity>
        where TContext : IEntity 
        where TEntity : IEntity
    {
        private PriorityEntityUpdater<TEntity> _updater;
        private IEntityTrigger<TEntity>[] _triggers;

        private float _priorityCooldown;
        private float _priorityTime;
        
#if ENABLE_PROFILER
        private ProfilerMarker _marker;
#endif
        
        protected PriorityEntitySystem()
        {
            _marker = new ProfilerMarker(this.GetType().Name + ".Update");
        }
        
        public sealed override void Init(TContext context)
        {
            base.Init(context);
            _updater = new PriorityEntityUpdater<TEntity>(this.ProvideUpdateSettings(context), this.Update, _entities.Count);
            _triggers = this.ProvidePriorityTriggers(context).ToArray();
            
            for (int i = 0, count = _triggers.Length; i < count; i++)
                _triggers[i].SetAction(this.SyncPriority);
            
            this.OnInit(context);
        }
        
        protected abstract PriorityEntityUpdateSettings ProvideUpdateSettings(TContext context);
        
        protected abstract IEnumerable<IEntityTrigger<TEntity>> ProvidePriorityTriggers(TContext context);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnInit(TContext context)
        {
        }
      
        public sealed override void Enable(TContext context)
        {
            base.Enable(context);
            this.OnEnable(context);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnEnable(TContext context)
        {
        }

        public sealed override void Disable(TContext context)
        {
            this.OnDisable(context);
            _updater.Dispose();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnDisable(TContext context)
        {
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void OnEntityAdded(TEntity entity)
        {
            _updater.Add(entity, this.GetPriority(entity));
                 
            for (int i = 0, count = _triggers.Length; i < count; i++)
                _triggers[i].Track(entity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void OnEntityRemoved(TEntity entity)
        {
            for (int i = 0, count = _triggers.Length; i < count; i++)
                _triggers[i].Untrack(entity);
            
            _updater.Remove(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private protected void Update(float deltaTime)
        {
#if ENABLE_PROFILER
            using (_marker.Auto())
#endif
                _updater.Update(deltaTime);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract void Update(TEntity entity, float deltaTime);

        protected abstract EntityUpdatePriority GetPriority(TEntity entity);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void RecalculatePriority()
        {
            foreach (TEntity entity in _entities) 
                _updater.ChangePriority(entity, this.GetPriority(entity));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void SyncPriority(TEntity entity) => 
            _updater.ChangePriority(entity, this.GetPriority(entity));

        #region Debug

        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int entityCount => _updater?._entityCount ?? -1;
        
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int batchSize => _updater?._batchSize ?? -1;

        [PropertySpace]
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int lowEntityCount => _updater?._lowCount ?? -1;
        
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int midEntityCount => _updater?._midCount ?? -1;
        
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private int highEntityCount => _updater?._highCount ?? -1;
        
        [PropertySpace]
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private IReadOnlyList<TEntity> highEntities => _updater?._highBucket;
        
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private IReadOnlyList<TEntity> midEntities => _updater?._midBucket;
        
        [FoldoutGroup("Debug")]
        [ShowInInspector, HideInEditorMode]
        private IReadOnlyList<TEntity> lowEntities => _updater?._lowBucket;

        #endregion
    }
    
    public abstract class TickPriorityEntitySystem<TContext, TEntity> 
        : PriorityEntitySystem<TContext, TEntity>, IEntityTick<TContext>
        where TContext : IEntity
        where TEntity : IEntity
    {
        public virtual void Tick(TContext context, float deltaTime) => this.Update(deltaTime);
    }
    
    public abstract class FixedTickPriorityEntitySystem<TContext, TEntity> 
        : PriorityEntitySystem<TContext, TEntity>, IEntityFixedTick<TContext>
        where TContext : IEntity
        where TEntity : IEntity
    {
        public virtual void FixedTick(TContext context, float fixedDeltaTime) => this.Update(fixedDeltaTime);
    }
    
    public abstract class LateTickPriorityEntitySystem<TContext, TEntity> 
        : PriorityEntitySystem<TContext, TEntity>, IEntityLateTick<TContext>
        where TContext : IEntity
        where TEntity : IEntity
    {
        public virtual void LateTick(TContext context, float deltaTime) => this.Update(deltaTime);
    }
}