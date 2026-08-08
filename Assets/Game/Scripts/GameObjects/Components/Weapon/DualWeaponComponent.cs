using UnityEngine;

namespace Game
{
    public sealed class DualWeaponComponent : MonoBehaviour, AttackRequestComponent.ICondition
    {
        [SerializeField] private PushWeapon _pushWeapon;
        [SerializeField] private PushWeapon _tossWeapon;

        private AttackRequestComponent _pushRequest;
        private AttackRequestComponent _tossRequest;

        private void Awake()
        {
            _pushRequest = _pushWeapon.GetComponent<AttackRequestComponent>();
            _tossRequest = _tossWeapon.GetComponent<AttackRequestComponent>();

            _pushRequest.SetAction(_pushWeapon);
            _pushRequest.SetCondition(this);
            
            _tossRequest.SetAction(_tossWeapon);
            _tossRequest.SetCondition(this);
        }

        public void Push() => _pushRequest.Attack();
        public void Toss() => _tossRequest.Attack();
        
        public bool Evaluate() => !(_pushWeapon.IsAttacking || _tossWeapon.IsAttacking);
    }
}