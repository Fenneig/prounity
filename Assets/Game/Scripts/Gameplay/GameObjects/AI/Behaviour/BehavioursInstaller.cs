using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class BehavioursInstaller : IBlackboardInstaller
    {
        [SerializeField] private AutoCombatBehaviour _autoCombatBehaviour;
        
        public void Install(Blackboard blackboard)
        {
            blackboard.SetReferenceValue(BlackboardAPI.AutoCombatBehaviour, _autoCombatBehaviour);
        }
    }
}