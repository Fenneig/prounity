using UnityEngine;

namespace Game.Entities
{
    public sealed class HealthPickUpInstaller : PickUpInstaller
    {
        [SerializeField] private int _amount;
        
        public override void Install(IGameEntity entity)
        {
            base.Install(entity);
            
            entity.GetInteractCommand()
                .AddCondition(target => target.CanHealTarget())
                .AddAction(target => target.Heal(_amount));
        }

    }
}