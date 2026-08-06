namespace Atomic.Elements
{
    public interface IParallelJob
    {
        void Execute(int start, int end);
    }
}