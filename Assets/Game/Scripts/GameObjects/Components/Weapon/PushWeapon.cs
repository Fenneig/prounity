using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(ForceComponent))]
    public sealed class PushWeapon : WeaponBaseComponent
    {
        private ForceComponent _forceComponent;

        protected override void Awake()
        {
            base.Awake();
            _forceComponent = GetComponent<ForceComponent>();
        }

        protected override void PerformAttack()
        {
            _forceComponent.ForceAtZone();
        }
    }
}