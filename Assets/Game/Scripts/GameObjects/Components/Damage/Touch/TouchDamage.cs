using UnityEngine;

namespace Game
{
    public class TouchDamage : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        public virtual void Damage(HealthComponent target) => 
            target.TakeDamage(_damage);
    }
}