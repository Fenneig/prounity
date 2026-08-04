using UnityEngine;

namespace Game
{
    public class AttackCooldownComponent : MonoBehaviour
    {
        private AttackRequestComponent _attackRequestComponent;
        private CooldownComponent _cooldownComponent;

        public bool IsAttacking => !_cooldownComponent.IsExpired;

        private void Awake()
        {
            _attackRequestComponent = GetComponent<AttackRequestComponent>();
            _cooldownComponent = GetComponent<CooldownComponent>();
        }

        private void OnEnable() => _attackRequestComponent.OnAttack += Attack;

        private void OnDisable() => _attackRequestComponent.OnAttack -= Attack;

        private void Attack() => _cooldownComponent.Reset();
    }
}