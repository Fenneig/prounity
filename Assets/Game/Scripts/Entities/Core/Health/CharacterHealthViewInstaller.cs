using System;
using Atomic.Entities;
using Game.UI;

namespace Game.Entities
{
    [Serializable]
    public class CharacterHealthViewInstaller : HealthViewInstaller
    {
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            
            entity.AddBehaviour(new HealthViewPresenter(GameUI.Instance));
        }
    }
}