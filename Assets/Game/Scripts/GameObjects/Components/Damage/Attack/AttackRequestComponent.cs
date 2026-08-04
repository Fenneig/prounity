using System;
using UnityEngine;

namespace Game
{
    public sealed class AttackRequestComponent : MonoBehaviour
    {
        public event Action OnAttack;

        private Action _action;
        private Func<bool> _condition;
        
        private bool _required;

        public void SetAction(Action action) => _action = action;
        public void SetCondition(Func<bool> condition) => _condition = condition;
        public void Attack() => _required = true;
        
        private void FixedUpdate()
        {
            if (_required && (_condition == null || _condition.Invoke()))
            {
                _action?.Invoke();
                OnAttack?.Invoke();
            }
            
            _required = false;
        }
    }
}