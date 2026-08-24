using System;
using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    public class CommandComponent : MonoBehaviour
    {
        [SerializeField] private Blackboard _blackboard;
        [SerializeField] private BaseCommand[] _commands;

        private readonly Queue<ICommandArgs> _queue = new();
        
        private ICommand _currentCommand;

        public void Add(ICommandArgs command)
        {
            Clear();
         
            PlayCommand(command);
        }
        
        public void Enqueue(ICommandArgs command)
        {
            if (_currentCommand is WaitCommand)
                Add(command);
            else
                _queue.Enqueue(command);
        }

        private void Clear()
        {
            StopCurrentCommand();
            _queue.Clear();
        }

        private void StopCurrentCommand()
        {
            _currentCommand.Stop();
            _currentCommand.OnComplete -= OnCommandComplete;
        }

        private void OnCommandComplete()
        {
            Debug.Log($"<color=yellow>Complete</color>: {_currentCommand}");
            _currentCommand.OnComplete -= OnCommandComplete;
            
            if (_queue.Count == 0)
                PlayDefaultCommand();
            else
                PlayNextQueueCommand();
        }

        private void PlayDefaultCommand() => 
            PlayCommand(new BaseCommand.BaseCommandArgs{CommandType = typeof(WaitCommand)});

        private void PlayNextQueueCommand() =>
            PlayCommand(_queue.Dequeue());

        private void PlayCommand(ICommandArgs commandArgs)
        {
            foreach (var command in _commands)
            {
                if (command.GetType() != commandArgs.CommandType)
                    continue;
                
                _currentCommand = command;
                _currentCommand.Initialize(commandArgs);
                _currentCommand.OnComplete += OnCommandComplete;
            
                Debug.Log($"<color=green>Start</color>: {command}");
                    
                return;
            }

            throw new Exception($"Command component {gameObject.name} does not have command {commandArgs.CommandType}");
        }

        private void Start() => 
            PlayDefaultCommand();

        private void FixedUpdate() => 
            _currentCommand?.FixedTick();
    }
}