using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.UI
{
    [Serializable]
    public class InputInstaller : IGameUIInstaller
    {
        [SerializeField] private Const<Joystick> _attackJoystick;
        [SerializeField] private Const<Joystick> _moveJoystick;
        
        public void Install(IGameUI ui)
        {
            ui.AddAttackJoystick(_attackJoystick);
            ui.AddMoveJoystick(_moveJoystick);
            
            ui.AddBehaviour(new InputController(GameContext.Instance));
        }
    }
}