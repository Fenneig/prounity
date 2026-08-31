using Atomic.Elements;

namespace Game.Entities.Weapon
{
    public static class WeaponUseCase
    {
        public static void CollectAmmo(this IGameEntity character, int amount)
        {
            IGameEntity weapon = character.GetWeapon().Value;
            IReactiveVariable<int> ammo = weapon.GetAmmo();
            
            ammo.Value += amount;
        }
    }
}