using System;

namespace Game.UI
{
    [Serializable]
    public class PlayerUIInstaller : IGameUIInstaller
    {
        public void Install(IGameUI entity)
        {
            entity.AddBehaviour(new AmmoPresenter(GameContext.Instance));
            entity.AddBehaviour(new HealthPresenter(GameContext.Instance));
            entity.AddBehaviour(new ScorePresenter(GameContext.Instance));
        }
    }
}