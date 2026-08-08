using System.Collections;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AttackRequestComponent))]
    public abstract class WeaponBaseComponent : MonoBehaviour, AttackRequestComponent.IAction
    {
        [SerializeField] private float _anticipationTime;
        [SerializeField] private float _cooldown;

        private float _startAttackTime;
        public bool IsAttacking => Time.time - (_startAttackTime + _anticipationTime) <= _cooldown;

        protected virtual void Awake()
        {
            _startAttackTime = Time.time;
        }

        public void Invoke()
        {
            _startAttackTime = Time.time;
            StartCoroutine(PrepareAttack());
        }

        private IEnumerator PrepareAttack()
        {
            yield return new WaitForSeconds(_anticipationTime);

            PerformAttack();
        }

        protected abstract void PerformAttack();
    }
}