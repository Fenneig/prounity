using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveInputHandler : InputHandler
    {
        [SerializeField]
        private InputHandler _next;

        public override void Handle(ref InputContext context)
        {
            if (context.rightClick)
            {
                ICommandArgs command = null;
                if (context.target != null && context.target != Blackboard.GetValue(BlackboardAPI.Character))
                {
                    command = new MoveToTargetCommand.MoveToTargetCommandArgs
                    {
                        CommandType = typeof(MoveToTargetCommand),
                        Target = context.target
                    };
                }
                else if (context.point != null)
                {
                    command = new MoveCommand.MoveCommandArgs
                    {
                        CommandType = typeof(MoveCommand),
                        TargetPosition = context.point.Value
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