using UnityEngine;

namespace Game
{
    public sealed class DealDamageComponent : MonoBehaviour
    {
        [SerializeField] private float _amount;

        public bool TryDealDamage(GameObject target)
        {
            if (target.TryGetComponent(out HealthComponent targetHp))
            {
                targetHp.TakeDamage(_amount);
                return true;
            }

            return false;
        }
    }
}