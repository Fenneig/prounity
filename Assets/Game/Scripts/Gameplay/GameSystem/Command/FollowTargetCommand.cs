using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class FollowTargetCommand : BaseCommand
    {
        public class FollowTargetCommandArgs : BaseCommandArgs
        {
            public GameObject Target;
        }
        
        [SerializeReference] private ICondition _followCondition;
        private MoveComponent _moveComponent;
        private GameObject _target;
        
        protected override void OnFixedTick()
        {
            if (_followCondition.Invoke())
            {
                Vector3 normalizedDirection = (_target.transform.position - _moveComponent.transform.position).normalized;
                
                _moveComponent.MoveStep(normalizedDirection, Time.fixedDeltaTime);
            }
        }

        public override void Initialize(ICommandArgs commandArgs)
        {
            var args = (FollowTargetCommandArgs)commandArgs;
            Blackboard.SetReferenceValue(BlackboardAPI.Target, args.Target);
            
            _moveComponent = Blackboard.GetValue(BlackboardAPI.Character).GetComponent<MoveComponent>();
            _target = Blackboard.GetValue(BlackboardAPI.Target);
        }
        
        public override string ToString() => $"{base.ToString()} {_moveComponent.name} follows {_target.name}";
    }
}