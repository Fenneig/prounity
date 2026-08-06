using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Atomic.Entities
{
    public class EntityUpdater<E> : EntityUpdaterBase where E : IEntity
    {
        private protected int _cursor;

        private readonly Dictionary<E, int> _lookup;
        private readonly Action<E, float> _action;
        internal E[] _entities;

        public EntityUpdater(EntityUpdateSettings settings, Action<E, float> action, int initialCapacity = 32) : base(settings)
        {
            _action = action;
            _entities = new E[Math.Max(4, initialCapacity)];
            _lookup = new Dictionary<E, int>(initialCapacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Dispose()
        {
            Array.Clear(_entities, 0, _entityCount);
            _lookup.Clear();
            base.Dispose();
        }

        public void Add(E entity)
        {
            if (_lookup.ContainsKey(entity))
                return;

            if (_entityCount >= _entities.Length)
                Array.Resize(ref _entities, _entities.Length * 2);

            _entities[_entityCount] = entity;
            _lookup[entity] = _entityCount;
            _entityCount++;
        }

        public void Remove(E entity)
        {
            if (!_lookup.TryGetValue(entity, out int index))
                return;

            int last = _entityCount - 1;
            if (index != last)
                this.Swap(index, last);

            _lookup.Remove(entity);
            _entityCount--;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateInternal(float deltaTime)
        {
            int count = _entityCount;
            if (count == 0)
                return;

            int cursor = _cursor;
            int batchSize = count < _batchSize ? count : _batchSize;
            for (int i = 0; i < batchSize; i++)
            {
                if (cursor >= count)
                    cursor = 0;

                _action(_entities[cursor++], deltaTime);
            }

            _cursor = cursor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Swap(int index, int last)
        {
            _entities[index] = _entities[last];
            _lookup[_entities[index]] = index;
        }
    }
}


