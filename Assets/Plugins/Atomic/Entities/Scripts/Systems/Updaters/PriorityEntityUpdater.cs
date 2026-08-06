using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Atomic.Entities
{
    public class PriorityEntityUpdater<E> : EntityUpdaterBase where E : IEntity
    {
        private new readonly PriorityEntityUpdateSettings _settings;

        private readonly Action<E, float> _action;

        internal E[] _highBucket;
        internal E[] _midBucket;
        internal E[] _lowBucket;

        internal int _highCount;
        internal int _midCount;
        internal int _lowCount;

        private struct Entry
        {
            public EntityUpdatePriority Priority;
            public int Index;
        }

        private readonly Dictionary<E, Entry> _lookup = new();

        private int _highCursor;
        private int _midCursor;
        private int _lowCursor;

        private bool _isProcessing;

        private struct Command
        {
            public enum Type : byte
            {
                Add,
                Remove,
                Priority
            }

            public Type CommandType;
            public E Entity;
            public EntityUpdatePriority Priority;
        }

        private readonly List<Command> _commands = new(64);

        public PriorityEntityUpdater(
            PriorityEntityUpdateSettings settings,
            Action<E, float> action,
            int initialCapacity = 32
        ) :
            base(settings)
        {
            _settings = settings;
            _action = action ?? throw new ArgumentNullException(nameof(action));

            initialCapacity = Math.Max(16, initialCapacity);

            _highBucket = new E[initialCapacity];
            _midBucket = new E[initialCapacity];
            _lowBucket = new E[initialCapacity];
        }

        public void Add(E entity, EntityUpdatePriority priority)
        {
            if (_isProcessing)
            {
                _commands.Add(new Command
                {
                    CommandType = Command.Type.Add,
                    Entity = entity,
                    Priority = priority
                });
                return;
            }

            AddInternal(entity, priority);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddInternal(E entity, EntityUpdatePriority priority)
        {
            if (_lookup.ContainsKey(entity))
                return;

            _entityCount++;

            switch (priority)
            {
                case EntityUpdatePriority.High:
                {
                    if (_highCount == _highBucket.Length)
                        Array.Resize(ref _highBucket, _highBucket.Length * 2);

                    _highBucket[_highCount] = entity;
                    _lookup[entity] = new Entry {Priority = priority, Index = _highCount};
                    _highCount++;
                    break;
                }

                case EntityUpdatePriority.Medium:
                {
                    if (_midCount == _midBucket.Length)
                        Array.Resize(ref _midBucket, _midBucket.Length * 2);

                    _midBucket[_midCount] = entity;
                    _lookup[entity] = new Entry {Priority = priority, Index = _midCount};
                    _midCount++;
                    break;
                }

                case EntityUpdatePriority.Low:
                default:
                {
                    if (_lowCount == _lowBucket.Length)
                        Array.Resize(ref _lowBucket, _lowBucket.Length * 2);

                    _lowBucket[_lowCount] = entity;
                    _lookup[entity] = new Entry {Priority = priority, Index = _lowCount};
                    _lowCount++;
                    break;
                }
            }
        }

        public void Remove(E entity)
        {
            if (_isProcessing)
            {
                _commands.Add(new Command
                {
                    CommandType = Command.Type.Remove,
                    Entity = entity
                });
                return;
            }

            RemoveInternal(entity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RemoveInternal(E entity)
        {
            if (!_lookup.Remove(entity, out Entry entry))
                return;

            _entityCount--;

            EntityUpdatePriority p = entry.Priority;
            int index = entry.Index;

            switch (p)
            {
                case EntityUpdatePriority.High:
                {
                    int last = _highCount - 1;
                    if (index != last)
                    {
                        E lastEntity = _highBucket[last];
                        _highBucket[index] = lastEntity;

                        Entry lastEntry = _lookup[lastEntity];
                        lastEntry.Index = index;
                        _lookup[lastEntity] = lastEntry;
                    }

                    _highBucket[last] = default;
                    _highCount--;

                    if (_highCursor >= _highCount)
                        _highCursor = 0;
                    break;
                }

                case EntityUpdatePriority.Medium:
                {
                    int last = _midCount - 1;
                    if (index != last)
                    {
                        E lastEntity = _midBucket[last];
                        _midBucket[index] = lastEntity;

                        Entry lastEntry = _lookup[lastEntity];
                        lastEntry.Index = index;
                        _lookup[lastEntity] = lastEntry;
                    }

                    _midBucket[last] = default;
                    _midCount--;

                    if (_midCursor >= _midCount)
                        _midCursor = 0;
                    break;
                }

                case EntityUpdatePriority.Low:
                default: // Low
                {
                    int last = _lowCount - 1;
                    if (index != last)
                    {
                        E lastEntity = _lowBucket[last];
                        _lowBucket[index] = lastEntity;

                        Entry lastEntry = _lookup[lastEntity];
                        lastEntry.Index = index;
                        _lookup[lastEntity] = lastEntry;
                    }

                    _lowBucket[last] = default;
                    _lowCount--;

                    if (_lowCursor >= _lowCount)
                        _lowCursor = 0;
                    break;
                }
            }
        }

        public void ChangePriority(E entity, EntityUpdatePriority priority)
        {
            if (_isProcessing)
            {
                _commands.Add(new Command
                {
                    CommandType = Command.Type.Priority,
                    Entity = entity,
                    Priority = priority
                });
                return;
            }

            ChangePriorityInternal(entity, priority);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ChangePriorityInternal(E entity, EntityUpdatePriority priority)
        {
            if (!_lookup.TryGetValue(entity, out var entry))
                return;

            if (entry.Priority == priority)
                return;

            int index = entry.Index;

            // ===== REMOVE =====
            switch (entry.Priority)
            {
                case EntityUpdatePriority.High:
                {
                    int last = _highCount - 1;

                    if (index != last)
                    {
                        E lastEntity = _highBucket[last];
                        _highBucket[index] = lastEntity;

                        var lastEntry = _lookup[lastEntity];
                        lastEntry.Index = index;
                        _lookup[lastEntity] = lastEntry;
                    }

                    _highBucket[last] = default;
                    _highCount--;
                    _highCursor = Math.Min(_highCursor, _highCount);
                    break;
                }

                case EntityUpdatePriority.Medium:
                {
                    int last = _midCount - 1;

                    if (index != last)
                    {
                        E lastEntity = _midBucket[last];
                        _midBucket[index] = lastEntity;

                        var lastEntry = _lookup[lastEntity];
                        lastEntry.Index = index;
                        _lookup[lastEntity] = lastEntry;
                    }

                    _midBucket[last] = default;
                    _midCount--;
                    _midCursor = Math.Min(_midCursor, _midCount);
                    break;
                }

                case EntityUpdatePriority.Low:
                default:
                {
                    int last = _lowCount - 1;

                    if (index != last)
                    {
                        E lastEntity = _lowBucket[last];
                        _lowBucket[index] = lastEntity;

                        var lastEntry = _lookup[lastEntity];
                        lastEntry.Index = index;
                        _lookup[lastEntity] = lastEntry;
                    }

                    _lowBucket[last] = default;
                    _lowCount--;
                    _lowCursor = Math.Min(_lowCursor, _lowCount);
                    break;
                }
            }

            // ===== ADD =====
            switch (priority)
            {
                case EntityUpdatePriority.High:
                {
                    if (_highCount == _highBucket.Length)
                        Array.Resize(ref _highBucket, _highBucket.Length * 2);

                    _highBucket[_highCount] = entity;
                    _lookup[entity] = new Entry {Priority = priority, Index = _highCount};
                    _highCount++;
                    break;
                }

                case EntityUpdatePriority.Medium:
                {
                    if (_midCount == _midBucket.Length)
                        Array.Resize(ref _midBucket, _midBucket.Length * 2);

                    _midBucket[_midCount] = entity;
                    _lookup[entity] = new Entry {Priority = priority, Index = _midCount};
                    _midCount++;
                    break;
                }

                case EntityUpdatePriority.Low:
                default:
                {
                    if (_lowCount == _lowBucket.Length)
                        Array.Resize(ref _lowBucket, _lowBucket.Length * 2);

                    _lowBucket[_lowCount] = entity;
                    _lookup[entity] = new Entry {Priority = priority, Index = _lowCount};
                    _lowCount++;
                    break;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateInternal(float deltaTime)
        {
            _isProcessing = true;
            int batch = _batchSize;

            int highQuota = batch * _settings.highPercent / 100;
            int midQuota = batch * _settings.midPercent / 100;
            int lowQuota = batch - highQuota - midQuota;

            // ===== HIGH =====
            int highProcessed = 0;
            if (_highCount > 0 && highQuota > 0)
            {
                int toProcess = Math.Min(highQuota, _highCount);
                int cursor = _highCursor;
                int count = _highCount;
                E[] array = _highBucket;

                for (int i = 0; i < toProcess; i++)
                {
                    if (cursor >= count)
                        cursor = 0;

                    _action(array[cursor++], deltaTime);
                }

                _highCursor = cursor;
                highProcessed = toProcess;
            }

            int remaining = highQuota - highProcessed;

            // ===== MID =====
            int midBudget = midQuota + (remaining > 0 ? remaining : 0);
            int midProcessed = 0;

            if (_midCount > 0 && midBudget > 0)
            {
                int toProcess = Math.Min(midBudget, _midCount);
                int cursor = _midCursor;
                int count = _midCount;
                E[] array = _midBucket;

                for (int i = 0; i < toProcess; i++)
                {
                    if (cursor >= count)
                        cursor = 0;

                    _action(array[cursor++], deltaTime);
                }

                _midCursor = cursor;
                midProcessed = toProcess;
            }

            remaining = midBudget - midProcessed;

            // ===== LOW =====
            int lowBudget = lowQuota + (remaining > 0 ? remaining : 0);

            if (_lowCount > 0 && lowBudget > 0)
            {
                int toProcess = Math.Min(lowBudget, _lowCount);
                int cursor = _lowCursor;
                int count = _lowCount;
                E[] array = _lowBucket;

                for (int i = 0; i < toProcess; i++)
                {
                    if (cursor >= count)
                        cursor = 0;

                    _action(array[cursor++], deltaTime);
                }

                _lowCursor = cursor;
            }

            _isProcessing = false;

            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < _commands.Count; i++)
            {
                var cmd = _commands[i];
                switch (cmd.CommandType)
                {
                    case Command.Type.Add:
                        AddInternal(cmd.Entity, cmd.Priority);
                        break;

                    case Command.Type.Remove:
                        RemoveInternal(cmd.Entity);
                        break;

                    case Command.Type.Priority:
                        ChangePriorityInternal(cmd.Entity, cmd.Priority);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _commands.Clear();
        }
    }
}