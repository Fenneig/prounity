using Game.Utils;

namespace Game.Systems.Damage
{
    public interface IDamageable
    {
        void ApplyDamage(int amount);
        TeamType Team { get; }
    }
}