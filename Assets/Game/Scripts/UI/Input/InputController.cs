using Atomic.Elements;
using Game.Entities;
using UnityEngine;

namespace Game.UI
{
    public class InputController : IGameUIInit, IGameUITick
    {
        private readonly GameContext _context;
        
        private Joystick _attackJoystick;
        private Joystick _moveJoystick;
        private IRequest<Vector3> _moveRequest;
        private IRequest<Vector3> _rotateRequest;
        private IRequest _fireRequest;
        private IReactiveVariable<bool> _wantToFire;

        public InputController(GameContext context)
        {
            _context = context;
        }
        
        public void Init(IGameUI entity)
        {
            _moveRequest = _context.GetCharacter().GetMoveRequest();
            _rotateRequest = _context.GetCharacter().GetRotateRequest();
            _fireRequest = _context.GetCharacter().GetFireRequest();
            _wantToFire = _context.GetCharacter().GetWeapon().Value.GetWantsToFire();
            
            _attackJoystick = entity.GetAttackJoystick().Value;
            _moveJoystick = entity.GetMoveJoystick().Value;
        }

        public void Tick(IGameUI entity, float deltaTime)
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