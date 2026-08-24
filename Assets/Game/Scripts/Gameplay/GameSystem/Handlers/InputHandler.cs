using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        
        protected Blackboard Blackboard;
        protected CommandComponent CommandComponent;

        private void Awake()
        {
            Blackboard = _character.GetComponentInChildren<Blackboard>();
            CommandComponent = _character.GetComponentInChildren<CommandComponent>();
        }
        
        public abstract void Handle(ref InputContext context);
    }
}