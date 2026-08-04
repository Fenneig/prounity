using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class WeaponState : MonoBehaviour
    {
        [SerializeField] private List<AttackCooldownComponent> _weapons;

        public bool CanAttack => _weapons.All(weapon => !weapon.IsAttacking);
    }
}