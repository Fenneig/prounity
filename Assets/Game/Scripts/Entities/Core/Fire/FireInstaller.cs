using System;
using Atomic.Elements;

namespace Game.Entities
{
    [Serializable]
    public sealed class FireInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddFireRequest(new Request());
            entity.AddFireCommand(new Command());
            entity.AddBehaviour(new FireBehaviour());
        }
    }
}