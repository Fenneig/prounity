using System;

namespace Atomic.Entities
{
    public abstract class EntityUpdaterBase : IDisposable
    {
        protected readonly EntityUpdateSettings _settings;
        protected internal int _batchSize;
        protected internal int _entityCount;

        protected EntityUpdaterBase(EntityUpdateSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _batchSize = _settings.minBatchSize;
        }

        public void Update(float deltaTime)
        {
            long start = InternalUtils.GetTimestamp();
            this.UpdateInternal(deltaTime);
            long end = InternalUtils.GetTimestamp();

            float frameSize = (end - start) * InternalUtils.DeltaTick;
            _batchSize = frameSize > _settings.frameBudget
                ? Math.Max(_batchSize / _settings.batchScaleDown, _settings.minBatchSize)
                : Math.Min(_batchSize + _settings.batchStepUp, _settings.maxBatchSize);
        }

        protected abstract void UpdateInternal(float deltaTime);

        public virtual void Dispose()
        {
            _entityCount = 0;
        }
    }
}