using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class BaseCommand : MonoBehaviour, ICommand
    {
        public class BaseCommandArgs : ICommandArgs
        {
            public Type CommandType { get; set; }
        }
        
        public event Action OnComplete;

        [SerializeField] protected Blackboard Blackboard;
        [SerializeReference] private ICondition _completeCondition;
        
        public virtual void Initialize(ICommandArgs args)
        { }
        public virtual void Stop()
        { }

        public void FixedTick()
        {
            if (CheckConditions())
            {
                CommandComplete();
                return;
            }
            
            OnFixedTick();
        }

        private bool CheckConditions() => 
            _completeCondition != null && _completeCondition.Invoke();

        protected virtual void OnFixedTick()
        { }

        protected virtual void CommandComplete() => OnComplete?.Invoke();

        public override string ToString() => $"{GetType().Name}:";
    }
}