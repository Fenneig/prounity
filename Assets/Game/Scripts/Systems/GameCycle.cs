using System;
using UnityEngine;

namespace Game.Systems
{
    public sealed class GameCycle : MonoBehaviour
    {
        public event Action OnGameStarted, OnGameEnded;
        
        public void StartGame() => 
            OnGameStarted?.Invoke();
        public void EndGame() =>
            OnGameEnded?.Invoke();
    }
}