using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PushComponent))]
    public sealed class PushAttack : AttackComponent
    {
        private PushComponent _pushComponent;

        private void Awake() =>
            _pushComponent = GetComponent<PushComponent>();

        protected override void PerformAttack(Rigidbody2D target) => 
            _pushComponent.Push(target);
    }
}