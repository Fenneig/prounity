using UnityEngine;

namespace Game.Gameplay
{
    public sealed class HoldPositionHandler : InputHandler
    {
        [SerializeField]
        private KeyCode _keyCode = KeyCode.H;

        [SerializeField]
        private InputHandler _next;

        public override void Handle(ref InputContext context)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                ICommandArgs command = new HoldCommand.HoldCommandArgs
                {
                    CommandType = typeof(HoldCommand)
                };

                if (context.enqueueCommand) CommandComponent.Enqueue(command);
                else CommandComponent.Add(command);

            }
            else if (_next) 
                _next.Handle(ref context);
        }
    }
}