using System;
using Atomic.Elements;

namespace Game.Entities
{
    [Serializable]
    public class InteractableInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddInteractableTag();
            entity.AddInteractCommand(new Command<IGameEntity>());
        }
    }
}