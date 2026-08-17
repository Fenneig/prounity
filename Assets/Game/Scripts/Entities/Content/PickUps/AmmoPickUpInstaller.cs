using Atomic.Entities;
using Game.Entities.Weapon;
using UnityEngine;

namespace Game.Entities
{
    public sealed class AmmoPickUpInstaller : PickUpInstaller
    {
        [SerializeField] private int _amount;
        
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            entity.GetInteractCommand()
                .AddCondition(target => target.HasCharacterTag())
                .AddAction(target =>
            {
                target.CollectAmmo(_amount);
                Destroy(gameObject);
            });
        }
    }
}