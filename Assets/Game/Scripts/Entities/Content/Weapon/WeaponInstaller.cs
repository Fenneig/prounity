using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public abstract class WeaponInstaller : GameEntityInstaller
    {
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private Cooldown _anticipation;
        
        public override void Install(IGameEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddOwner(new Variable<IGameEntity>(null));

            entity.GetFireCommand()
                .AddCondition(() => entity.GetFireAnticipation().IsCompleted())
                .AddCondition(() => entity.GetWeaponCooldown().IsCompleted())
                .AddAction(() => entity.GetWeaponCooldown().ResetTime());
            
            InstallCooldown(entity);
            InstallAnticipation(entity);
        }

        private void InstallCooldown(IGameEntity entity)
        {
            entity.AddWeaponCooldown(_cooldown);
            entity.WhenFixedTick(_cooldown.Tick);
        }

        private void InstallAnticipation(IGameEntity entity)
        {
            entity.AddFireAnticipation(_anticipation);
            entity.AddWantsToFire(new ReactiveVariable<bool>(false));
            entity.WhenFixedTick(_anticipation.Tick);
            entity.AddBehaviour(new AnticipationBehaviour());
        }
    }
}