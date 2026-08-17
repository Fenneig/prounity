using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.UI
{
    [Serializable]
    public class InputInstaller : IEntityInstaller<IGameUI>
    {
        [SerializeField] private Const<Joystick> _attackJoystick;
        [SerializeField] private Const<Joystick> _moveJoystick;
        
        public void Install(IGameUI ui)
        {
            ui.AddAttackJoystick(_attackJoystick);
            ui.AddMoveJoystick(_moveJoystick);
        }
    }
}