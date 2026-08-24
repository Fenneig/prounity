using System;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class WeaponInstaller : IBlackboardInstaller
    {
        [SerializeField] private Weapon _weapon;
        
        public void Install(Blackboard blackboard) => 
            blackboard.AddReferenceValue(BlackboardAPI.Weapon, _weapon);
    }
}