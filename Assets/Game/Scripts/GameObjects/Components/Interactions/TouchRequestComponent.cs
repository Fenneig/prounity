using UnityEngine;

namespace Game
{
    public sealed class TouchRequestComponent : MonoBehaviour
    {
        public interface IAction
        {
            void Invoke(GameObject target);
        }
        
        public interface ICondition
        {
            bool Evaluate();
        }

        private IAction _action;
        private ICondition _condition;

        private GameObject _target;

        public void SetAction(IAction action) => _action = action;
        public void SetCondition(ICondition condition) => _condition = condition;
        public void Touch(Collision2D target) => _target = target.gameObject;

        private void Update()
        {
            if (_target != null && (_condition == null || _condition.Evaluate()))
                _action.Invoke(_target);

            _target = null;
        }
    }
}