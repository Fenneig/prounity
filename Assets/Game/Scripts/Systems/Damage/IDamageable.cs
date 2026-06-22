using Game.Utils;

namespace Game.Systems
{
    public interface IDamageable
    {
        void ApplyDamage(int amount);
        TeamType Team { get; }
    }
}