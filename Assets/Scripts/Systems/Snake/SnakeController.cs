using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class SnakeController : IInitializable, IDisposable
    {
        private ISnake _snake;
        private CoinsWorld _coinsWorld;
        private IDifficulty _difficulty;
        private GameState _gameState;
        private IWorldBounds _worldBounds;

        public SnakeController(
            ISnake snake, 
            CoinsWorld coinsWorld, 
            IDifficulty difficulty, 
            GameState gameState, 
            IWorldBounds worldBounds)
        {
            _snake = snake;
            _coinsWorld = coinsWorld;
            _difficulty = difficulty;
            _gameState = gameState;
            _worldBounds = worldBounds;
        }

        private void Lose() => 
            _gameState.GameOver(false);

        private void HandleSnakeSpeed() => 
            _snake.SetSpeed(_difficulty.Current);
        
        private void HandleSnakeMove(Vector2Int newPosition)
        {
            if (!_worldBounds.IsInBounds(newPosition))
            {
                Lose();
                return;
            }
        
            _coinsWorld.TryRemoveCoin(newPosition);
        }

        private void Expand(ICoin eatenCoin) => 
            _snake.Expand(eatenCoin.Bones);

        public void Initialize()
        {
            _coinsWorld.OnCoinRemoved += Expand;
            _difficulty.OnStateChanged += HandleSnakeSpeed;
            _snake.OnSelfCollided += Lose;
            _snake.OnMoved += HandleSnakeMove;
        }

        public void Dispose()
        {
            _coinsWorld.OnCoinRemoved -= Expand;
            _difficulty.OnStateChanged -= HandleSnakeSpeed;
            _snake.OnSelfCollided -= Lose;
            _snake.OnMoved -= HandleSnakeMove;
        }
    }
}