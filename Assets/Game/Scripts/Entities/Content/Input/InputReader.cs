using Atomic.Entities;
using Game.UI;
using UnityEngine;

namespace Game.Entities
{
    public sealed class InputReader : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;
        [SerializeField] private Joystick _attackJoystick;
        [SerializeField] private Joystick _moveJoystick;
        
        private void Update()
        {
            HandleMove(_moveJoystick.Direction);
            HandleFire(_attackJoystick.Direction);
        }

        private void HandleMove(Vector2 moveJoystickDirection)
        {
            Vector3 direction = new Vector3(moveJoystickDirection.x, 0, moveJoystickDirection.y);
            _character.GetMoveRequest().Invoke(direction);
        }

        private void HandleFire(Vector2 lookJoystickDirection)
        {
            bool wantToFire = lookJoystickDirection.magnitude != 0;
            _character.GetWeapon().Value.GetWantsToFire().Value = wantToFire;
            
            if (!wantToFire)
                return;
            
            Vector3 direction = new Vector3(lookJoystickDirection.x, 0, lookJoystickDirection.y);
            _character.GetRotateRequest().Invoke(direction);
            _character.GetFireRequest().Invoke();
        }
    }
}