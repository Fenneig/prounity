using UnityEngine;

namespace Game
{
    public abstract class WeaponBaseComponent : MonoBehaviour, AttackRequestComponent.IAction, AttackRequestComponent.ICondition
    {
        [SerializeField] private float _cooldown;
        
        private float _startAttackTime;
        
        public bool CanAttack => Time.time - _startAttackTime > _cooldown;
        
        protected virtual void Awake()
        {
            _startAttackTime = Time.time;
            AttackRequestComponent attackRequestComponent = GetComponent<AttackRequestComponent>();
            
            attackRequestComponent.SetAction(this);
            attackRequestComponent.SetCondition(this);
        }
        
        public virtual void Attack() => _startAttackTime = Time.time;

        void AttackRequestComponent.IAction.Invoke() => Attack();

        bool AttackRequestComponent.ICondition.Evaluate() => CanAttack;
    }
}