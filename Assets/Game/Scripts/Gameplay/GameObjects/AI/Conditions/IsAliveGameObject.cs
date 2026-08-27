using System;
using Game.Gameplay.Core;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class IsAliveGameObject : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        [SerializeField]
        [BlackboardValueKey(typeof(GameObject))]
        private string _key;
        
        public bool Invoke() =>
            _blackboard.TryGetValue(_key, out GameObject target) &&
            target != null &&
            target.TryGetComponent(out HealthComponent healthComponent) &&
            healthComponent.IsAlive;
    }
}