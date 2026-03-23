using Game.Utils;

namespace Game.Damage
{
    public interface IDamageable
    {
        void ApplyDamage(int amount);
        TeamType Team { get; }
    }
}