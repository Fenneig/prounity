using Game.Gameplay.Sensors;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AutoCombatBehaviour : MonoBehaviour
    {
        [SerializeField] private Blackboard _blackboard;
        [SerializeField] private EnemySensor _enemySensor;

        [SerializeField] private CombatBehaviour _combatBehaviour;
        private EnemyTargetSelector _targetSelector;

        private bool _isActive;

        private void Awake()
        {
            _targetSelector = new EnemyTargetSelector(_enemySensor, transform);
        }

        public void StartCombat()
        {
            if (_isActive)
                return;

            _isActive = true;

            _enemySensor.OnEnemyEnter += OnEnemyEnter;
            _enemySensor.OnEnemyExit += OnEnemyExit;

            SetTarget(_targetSelector.FindClosest());
        }

        public void StopCombat()
        {
            if (!_isActive)
                return;

            _isActive = false;

            _enemySensor.OnEnemyEnter -= OnEnemyEnter;
            _enemySensor.OnEnemyExit -= OnEnemyExit;

            ClearTarget();
        }

        public bool TryFixedTick(AutoCombatType type)
        {
            if (type == AutoCombatType.None || !_isActive)
                return false;

            return HasTarget() && _combatBehaviour.FixedTick(type);
        }

        private void OnEnemyEnter(GameObject enemy)
        {
            if (HasTarget())
                return;

            SetTarget(enemy);
        }

        private void OnEnemyExit(GameObject enemy)
        {
            if (_blackboard.TryGetValue(BlackboardAPI.FireTarget, out GameObject target) && target != enemy)
                return;

            SetTarget(_targetSelector.FindClosest());
        }

        private bool HasTarget() => 
            _blackboard.TryGetValue(BlackboardAPI.FireTarget, out GameObject target) && target != null;

        private void SetTarget(GameObject target)
        {
            if (target == null)
            {
                ClearTarget();
                return;
            }
            
            _blackboard.SetReferenceValue(BlackboardAPI.FireTarget, target);
            _blackboard.SetReferenceValue(BlackboardAPI.MoveTarget, target);
        }

        private void ClearTarget()
        {
            _blackboard.DelValue(BlackboardAPI.FireTarget);
            _blackboard.DelValue(BlackboardAPI.MoveTarget);
        }
    }
}