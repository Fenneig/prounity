using System;
using UnityEngine;

namespace Game.Systems.Enemies
{
    public sealed class EnemyDieMediator : MonoBehaviour
    {
        public event Action OnEnemyDied;
        
        public void EnemyDied() => OnEnemyDied?.Invoke();
    }
}