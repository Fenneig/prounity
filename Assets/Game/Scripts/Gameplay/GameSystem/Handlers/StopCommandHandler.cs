using UnityEngine;

namespace Game.Gameplay
{
    public sealed class StopCommandHandler : InputHandler
    {
        [SerializeField]
        private KeyCode _keyCode = KeyCode.S;
        
        [SerializeField]
        private InputHandler _next;
        
        public override void Handle(ref InputContext context)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                CommandComponent.ClearInternal();
            }
            else if (_next)
                _next.Handle(ref context);
        }
    }
}