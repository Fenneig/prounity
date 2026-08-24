using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AttackInputHandler : InputHandler
    {
        [SerializeField]
        private KeyCode _keyCode = KeyCode.A;

        [SerializeField]
        private InputHandler _next;
        
        public override void Handle(ref InputContext context)
        {
            if (Input.GetKey(_keyCode) && context.leftClick)
            {
                ICommandArgs commandArgs = null;
                if (context.point != null)
                {
                    commandArgs = new AttackPositionCommand.AttackPositionCommandArgs
                    {
                        CommandType = typeof(AttackPositionCommand),
                        TargetPosition = context.point.Value
                    };
                }
                else if (context.target != null && context.target != Blackboard.GetValue(BlackboardAPI.Character))
                {
                    commandArgs = new AttackTargetCommand.AttackTargetCommandArgs
                    {
                        CommandType = typeof(AttackTargetCommand),
                        Target = context.target
                    };
                }
                
                if (context.enqueueCommand) CommandComponent.Enqueue(commandArgs);
                else CommandComponent.Add(commandArgs);
            }
            else if (_next)
                _next.Handle(ref context);
        }
    }
}