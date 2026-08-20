using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public abstract class WeaponInstaller : SceneEntityInstaller
    {
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private Cooldown _anticipation;
        
        public override void Install(IEntity entity)
        {
            _fireInstaller.Install(entity);
            entity.AddOwner(new Variable<IEntity>(null));

            entity.GetFireCommand()
                .AddCondition(() => entity.GetFireAnticipation().IsCompleted())
                .AddCondition(() => entity.GetWeaponCooldown().IsCompleted())
                .AddAction(() => entity.GetWeaponCooldown().ResetTime());
            
            InstallCooldown(entity);
            InstallAnticipation(entity);
        }

        private void InstallCooldown(IEntity entity)
        {
            entity.AddWeaponCooldown(_cooldown);
            entity.WhenFixedTick(_cooldown.Tick);
        }

        private void InstallAnticipation(IEntity entity)
        {
            entity.AddFireAnticipation(_anticipation);
            entity.AddWantsToFire(new ReactiveVariable<bool>(false));
            entity.WhenFixedTick(_anticipation.Tick);
            entity.AddBehaviour(new AnticipationBehaviour());
        }
    }
}