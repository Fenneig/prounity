using UnityEngine;

namespace Game
{
    public sealed class CharacterWeapon : MonoBehaviour, AttackRequestComponent.IAction, AttackRequestComponent.ICondition
    {
        [SerializeField] private float _cooldown;
        
        private ForceComponent _forceComponent;
        private float _startAttackTime;

        public bool CanAttack => Time.time - _startAttackTime > _cooldown;
        
        private void Awake()
        {
            _startAttackTime = Time.time;
            AttackRequestComponent attackRequestComponent = GetComponent<AttackRequestComponent>();
            _forceComponent = GetComponent<ForceComponent>();
            
            attackRequestComponent.SetAction(this);
            attackRequestComponent.SetCondition(this);
        }

        private void Attack()
        {
            _startAttackTime = Time.time;
            _forceComponent.ForceAtZone();
        }
        
        void AttackRequestComponent.IAction.Invoke() => Attack();

        bool AttackRequestComponent.ICondition.Evaluate() => CanAttack;
    }
}