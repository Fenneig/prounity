using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    [Serializable]
    public class InteractableInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddInteractableTag();
            entity.AddInteractCommand(new Command<IEntity>());
        }
    }
}