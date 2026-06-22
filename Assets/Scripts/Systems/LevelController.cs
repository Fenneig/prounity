using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class LevelController : IInitializable, IDisposable
    {
        private CoinsWorld _coinsWorld;
        private IDifficulty _difficulty;
        private GameState _gameState;

        public LevelController(CoinsWorld coinsWorld, IDifficulty difficulty, GameState gameState)
        {
            _coinsWorld = coinsWorld;
            _difficulty = difficulty;
            _gameState = gameState;
        }

        private void UpdateLevel()
        {
            if (_difficulty.Current == _difficulty.Max)
                _gameState.GameOver(true);
            else
                _difficulty.Next(out int _);
        }

        private void LevelChanged()
        {
            for (int i = 0; i < _difficulty.Current; i++)
            {
                if (!_coinsWorld.TrySpawnCoin()) 
                    Debug.LogWarning($"No free space to spawn coin!");
            }
        }
        
        public void Initialize()
        {
            _coinsWorld.OnAllCoinsRemoved += UpdateLevel;
            _difficulty.OnStateChanged += LevelChanged;

            _difficulty.Next(out int _);
        }
        
        public void Dispose()
        {
            _coinsWorld.OnAllCoinsRemoved -= UpdateLevel;
            _difficulty.OnStateChanged -= LevelChanged;
        }
    }
}