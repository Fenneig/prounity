using System;
using System.Collections.Generic;
using System.Threading;

namespace Atomic.Elements
{
    public class AtomicReactiveVariable<T> : IReactiveVariable<T>, IDisposable, MainThreadDispatcher.IFlushable
    {
        private static readonly IEqualityComparer<T> s_comparer = EqualityComparer<T>.Default;
        private readonly object _lock = new();

        public event Action<T> OnEvent;

        private T _value;

        public T Value
        {
            get
            {
                lock (_lock)
                    return _value;
            }
            set
            {
                bool changed = false;

                lock (_lock)
                {
                    if (s_comparer.Equals(_value, value))
                        return;

                    _value = value;
                    changed = true;
                }

                if (changed)
                    MainThreadDispatcher.MarkDirty(this);
            }
        }

        public AtomicReactiveVariable() => _value = default;

        public AtomicReactiveVariable(T value) => _value = value;

        void MainThreadDispatcher.IFlushable.Flush()
        {
            T value;
            lock (_lock)
                value = _value;

            Action<T> handler = this.OnEvent;
            handler?.Invoke(value);
        }

        public void Dispose()
        {
            Interlocked.Exchange(ref OnEvent, null);
        }

        public override string ToString()
        {
            lock (_lock)
                return _value?.ToString();
        }
    }
}