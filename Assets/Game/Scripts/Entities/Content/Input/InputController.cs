using Atomic.Elements;
using Atomic.Entities;
using Game.UI;
using UnityEngine;

namespace Game.Entities
{
    public class InputController : IEntityInit, IEntityTick
    {
        private Joystick _attackJoystick;
        private Joystick _moveJoystick;
        private IRequest<Vector3> _moveRequest;
        private IRequest<Vector3> _rotateRequest;
        private IRequest _fireRequest;
        private IReactiveVariable<bool> _wantToFire;

        public InputController(IGameUI ui)
        {
            _attackJoystick = ui.GetAttackJoystick().Value;
            _moveJoystick = ui.GetMoveJoystick().Value;
        }
        
        public void Init(IEntity entity)
        {
            _moveRequest = entity.GetMoveRequest();
            _rotateRequest = entity.GetRotateRequest();
            _fireRequest = entity.GetFireRequest();
            _wantToFire = entity.GetWeapon().Value.GetWantsToFire();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            HandleMove(_moveJoystick.Direction);
            HandleFire(_attackJoystick.Direction);
        }

        private void HandleMove(Vector2 moveJoystickDirection)
        {
            Vector3 direction = new Vector3(moveJoystickDirection.x, 0, moveJoystickDirection.y);
            _moveRequest.Invoke(direction);
        }

        private void HandleFire(Vector2 lookJoystickDirection)
        {
            bool wantToFire = lookJoystickDirection.magnitude != 0;
            _wantToFire.Value = wantToFire;
            
            if (!wantToFire)
                return;
            
            Vector3 direction = new Vector3(lookJoystickDirection.x, 0, lookJoystickDirection.y);
            _rotateRequest.Invoke(direction);
            _fireRequest.Invoke();
        }
    }
}