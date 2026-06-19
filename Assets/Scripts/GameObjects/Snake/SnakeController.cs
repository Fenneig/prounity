using System;
using GameObjects.Coins;
using Modules;
using Zenject;

namespace GameObjects.Snake
{
    public sealed class SnakeController : IInitializable, IDisposable
    {
        private ISnake _snake;
        private CoinsWorld _coinsWorld;
        private IDifficulty _difficulty;
    
        [Inject]
        public void Construct(ISnake snake, CoinsWorld coinsWorld, IDifficulty difficulty)
        {
            _snake = snake;
            _coinsWorld = coinsWorld;
            _difficulty = difficulty;
        }
    
        public void Initialize()
        {
            _coinsWorld.OnCoinRemoved += Expand;
            _difficulty.OnStateChanged += HandleSnakeSpeed;
        }

        private void HandleSnakeSpeed() => 
            _snake.SetSpeed(_difficulty.Current);

        private void Expand(ICoin eatenCoin) => 
            _snake.Expand(eatenCoin.Bones);

        public void Dispose()
        {
            _coinsWorld.OnCoinRemoved -= Expand;
            _difficulty.OnStateChanged -= HandleSnakeSpeed;
        }
    }
}