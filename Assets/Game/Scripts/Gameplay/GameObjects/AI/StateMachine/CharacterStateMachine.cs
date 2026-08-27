using System;
using System.Collections.Generic;
using System.Linq;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterStateMachine : MonoBehaviour, IStateSwitcher
    {
        [SerializeField] private Blackboard _blackboard;
        
        private List<IState> _states;
        private IState _currentState;
        
        public IState CurrentState => _currentState;

        private void Start()
        {
            _states = new List<IState>
            {
                new IdleState(),
                new MoveState(_blackboard),
                new MoveToTargetState(_blackboard),
                new AttackState(_blackboard),
                new RotateState(_blackboard)
            };
            
            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>(ICondition condition = null) where T : IState
        {
            if (_currentState is T)
                return;
            
            try
            {
                _currentState = _states.FirstOrDefault(state => state is T);
                _currentState.Enter();
                _currentState.SetCondition(condition);
            }
            catch (Exception _)
            {
                Debug.LogError($"There is no state {typeof(T).Name}) in state machine!");
            }
        }

        private void FixedUpdate()
        {
            _currentState.OnFixedTick();
        }
    }
}