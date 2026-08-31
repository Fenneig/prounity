using System;

namespace Game.UI
{
    [Serializable]
    public class PlayerUIInstaller : IGameUIInstaller
    {
        public void Install(IGameUI entity)
        {
            entity.AddBehaviour(new AmmoViewPresenter(GameContext.Instance));
            entity.AddBehaviour(new HealthViewPresenter(GameContext.Instance));
            entity.AddBehaviour(new ScoreViewPresenter(GameContext.Instance));
        }
    }
}