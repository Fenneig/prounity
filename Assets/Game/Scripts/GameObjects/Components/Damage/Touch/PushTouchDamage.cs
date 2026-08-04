using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PushComponent))]
    public class PushTouchDamage : TouchDamage
    {
        private PushComponent _pushComponent;

        private void Awake() => 
            _pushComponent = GetComponent<PushComponent>();

        public override void Damage(HealthComponent healthComponent)
        {
            base.Damage(healthComponent);

            Push(healthComponent.gameObject);
        }

        private void Push(GameObject target)
        {
            if (!target.gameObject.TryGetComponent(out Rigidbody2D rb))
                throw new Exception($"{((Component)this).gameObject.name} trying attack target without rigidbody: {target.gameObject.name}");

            _pushComponent.Push(rb);
        }
    }
}