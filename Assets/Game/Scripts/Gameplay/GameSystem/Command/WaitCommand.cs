using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class WaitCommand : BaseCommand
    {
        private Vector3 _holdPosition;

        public override void Initialize(ICommandArgs _)
        {
            _holdPosition = Blackboard.GetValue(BlackboardAPI.Character).transform.position;
        }

        public override string ToString() => $"{base.ToString()}: Waiting at position {_holdPosition}";
    }
}