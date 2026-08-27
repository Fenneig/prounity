using System;

namespace Game.Gameplay
{
    public interface ICommand
    {
        event Action OnComplete;
        void Initialize(ICommandArgs args);
        void Stop();
        void FixedTick();
        EnqueueResult HandleEnqueue(ICommandArgs commandArgs);
    }
}