using System;
using System.Threading;

namespace Atomic.Elements
{
    public static class ParallelWorker
    {
        private static Thread[] _workers;
        private static int _workerCount;

        private static volatile bool _initialized;

        private static IParallelJob _job;
        private static int _end;
        private static int _nextIndex;
        private static int _chunkSize;

        private static int _activeWorkers;

        private static readonly ManualResetEventSlim _workEvent = new(false);
        private static readonly ManualResetEventSlim _doneEvent = new(true);

        public static void Initialize(int workerCount = -1)
        {
            if (_initialized)
                return;

            _workerCount = workerCount > 0
                ? workerCount
                : Math.Max(1, Environment.ProcessorCount - 1);

            _workers = new Thread[_workerCount];

            for (int i = 0; i < _workerCount; i++)
            {
                _workers[i] = new Thread(WorkerLoop)
                {
                    IsBackground = true
                };
                _workers[i].Start();
            }

            _initialized = true;
        }

        public static void For(int start, int end, int batchSize, IParallelJob job)
        {
            if (!_initialized)
                Initialize();

            _job = job;
            _end = end;

            int total = end - start;

            // 🔥 главный фактор производительности
            _chunkSize = batchSize > 0
                ? batchSize
                : Math.Max(64, total / (_workerCount * 2));

            _nextIndex = start;
            _activeWorkers = _workerCount + 1;

            _doneEvent.Reset();
            _workEvent.Set();

            // main thread тоже работает
            Execute();

            _doneEvent.Wait();
            _workEvent.Reset();
        }

        private static void WorkerLoop()
        {
            while (true)
            {
                _workEvent.Wait();
                Execute();
            }
        }

        private static void Execute()
        {
            var job = _job;

            while (true)
            {
                int start = Interlocked.Add(ref _nextIndex, _chunkSize) - _chunkSize;
                if (start >= _end)
                    break;

                int end = Math.Min(start + _chunkSize, _end);
                job.Execute(start, end);
            }

            if (Interlocked.Decrement(ref _activeWorkers) == 0)
            {
                _doneEvent.Set();
            }
        }
    }
}