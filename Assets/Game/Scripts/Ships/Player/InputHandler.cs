using System;
using UnityEngine;

namespace Game.Ships.Player
{
    public sealed class InputHandler : MonoBehaviour
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;

        private Vector2 _moveDirection;
        
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnFire?.Invoke();

            _moveDirection.x = Input.GetAxisRaw(HORIZONTAL_AXIS);
            _moveDirection.y = Input.GetAxisRaw(VERTICAL_AXIS);

            OnMove?.Invoke(_moveDirection.normalized);
        }
    }
}