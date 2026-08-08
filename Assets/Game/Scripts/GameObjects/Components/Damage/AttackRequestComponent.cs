using System;
using UnityEngine;

namespace Game
{
    public sealed class AttackRequestComponent : MonoBehaviour
    {
        public event Action OnAttack;

        public interface IAction
        {
            void Invoke();
        }
        
        public interface ICondition
        {
            bool Evaluate();
        }

        private IAction _action;
        private ICondition _condition;
        
        private bool _required;

        public void SetAction(IAction action) => _action = action;
        
        public void SetCondition(ICondition condition) => _condition = condition;
        
        public void Attack() => _required = true;
        
        private void FixedUpdate()
        {
            if (_required && (_condition == null || _condition.Evaluate()))
            {
                _action?.Invoke();
                OnAttack?.Invoke();
            }
            
            _required = false;
        }
    }
}