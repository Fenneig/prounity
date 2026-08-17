using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities
{
    [Serializable]
    public sealed class FireInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddFireRequest(new Request());
            entity.AddFireCommand(new Command());
            entity.AddBehaviour(new FireBehaviour());
        }
    }
}