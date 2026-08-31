using System;

namespace Game.UI
{
    [Serializable]
    public class AmmoViewInstaller : IGameUIInstaller
    {
        public void Install(IGameUI entity)
        {
            entity.AddBehaviour(new AmmoViewPresenter(GameContext.Instance));
        }
    }
}