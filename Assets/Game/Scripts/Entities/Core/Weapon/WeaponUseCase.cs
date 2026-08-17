using Atomic.Elements;
using Atomic.Entities;

namespace Game.Entities.Weapon
{
    public static class WeaponUseCase
    {
        public static void CollectAmmo(this IEntity character, int amount)
        {
            IEntity weapon = character.GetWeapon().Value;
            IReactiveVariable<int> ammo = weapon.GetAmmo();
            
            ammo.Value += amount;
        }
    }
}