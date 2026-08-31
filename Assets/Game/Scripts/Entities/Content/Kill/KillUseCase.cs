namespace Game.Entities
{
    public static class KillUseCase
    {
        public static void ProcessKill(this IGameEntity _)
        {
            var score = GameContext.Instance.GetScore();

            score.Value++;
        }
    }
}