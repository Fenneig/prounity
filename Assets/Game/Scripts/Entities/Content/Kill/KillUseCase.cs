using Atomic.Entities;

namespace Game.Entities
{
    public static class KillUseCase
    {
        public static void ProcessKill(this IEntity entity)
        {
            if (entity.TryGetScore(out var score))
                score.Value++;
        }
    }
}