using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class FollowInputHandler : InputHandler
    {
        [SerializeField]
        private KeyCode _keyCode = KeyCode.F;

        [SerializeField]
        private InputHandler _next;

        public override void Handle(ref InputContext context)
        {
            if (Input.GetKey(_keyCode) && context.leftClick)
            {
                ICommandArgs command = null;
                if (context.point != null)
                {
                    // TODO: Follow point ? 
                    command = new MoveCommand.MoveCommandArgs
                    {
                        CommandType = typeof(MoveCommand),
                        TargetPosition = context.point.Value
                    };
                }
                else if (context.target != null && Blackboard.GetValue(BlackboardAPI.Character) != context.target)
                {
                    command = new FollowTargetCommand.FollowTargetCommandArgs
                    {
                        CommandType = typeof(FollowTargetCommand),
                        Target = context.target
                    };
                }
                
                if (context.enqueueCommand) CommandComponent.Enqueue(command);
                else CommandComponent.Add(command);
            }
            else if (_next) 
                _next.Handle(ref context);
        }
    }
}