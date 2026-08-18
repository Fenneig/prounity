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

        public override void Attack()
        {
            base.Attack();
            
            _forceComponent.ForceAtZone();
        }
    }
}