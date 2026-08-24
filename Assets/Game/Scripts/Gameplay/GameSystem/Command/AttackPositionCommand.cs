using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackPositionCommand : BaseCommand
    {
        public class AttackPositionCommandArgs : BaseCommandArgs
        {
            public Vector3 TargetPosition;
        }
        
        public override void Initialize(ICommandArgs commandArgs)
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}