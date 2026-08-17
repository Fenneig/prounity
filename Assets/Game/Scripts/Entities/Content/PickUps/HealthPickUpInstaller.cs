using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class HealthPickUpInstaller : PickUpInstaller
    {
        [SerializeField] private int _amount;
        
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            
            entity.GetInteractCommand()
                .AddCondition(target => target.CanHealTarget())
                .AddAction(target =>
            {
                target.Heal(_amount);
                Destroy(gameObject);
            });
        }

    }
}