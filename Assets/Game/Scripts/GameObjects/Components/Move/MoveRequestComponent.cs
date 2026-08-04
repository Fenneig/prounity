using UnityEngine;

namespace Game
{
    public sealed class MoveRequestComponent : MonoBehaviour
    {
        [SerializeField]
        private float _moveDuration = 0.2f;

        private float _moveTime;
        
        public interface IAction
        {
            void Invoke(Vector2 direction);
        }
        
        public interface ICondition
        {
            bool Evaluate();
        }

        private IAction _action;
        private ICondition _condition;
        
        private Vector2 _direction;

        public bool IsMoving => Time.time <= _moveTime;

        public void Move(Vector2 normalizedDirection) => _direction = normalizedDirection;

        public void SetAction(IAction action) => _action = action;
        public void SetCondition(ICondition condition) => _condition = condition;

        private void FixedUpdate()
        {
            if (_direction != Vector2.zero && (_condition == null || _condition.Evaluate()))
            {
                _action.Invoke(_direction);

                _moveTime = Time.time + _moveDuration;
            }
        }
    }
}