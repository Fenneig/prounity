using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PatrolInputHandler : InputHandler
    {
        [SerializeField]
        private KeyCode _keyCode = KeyCode.P;
        
        [SerializeField]
        private InputHandler _next;

        public override void Handle(ref InputContext context)
        {
            if (Input.GetKey(_keyCode) && context.leftClick)
            {
                ICommandArgs command = null;
                if (context.point != null)
                {
                    command = new PatrolCommand.PatrolCommandArgs
                    {
                        CommandType = typeof(PatrolCommand),
                        Target = new PositionPatrolTarget(context.point.Value)
                    };
                }
                else if (context.target != null && context.target != Blackboard.GetValue(BlackboardAPI.Character))
                {
                    command = new PatrolCommand.PatrolCommandArgs
                    {
                        CommandType = typeof(PatrolCommand),
                        Target = new GameObjectPatrolTarget(context.target)
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