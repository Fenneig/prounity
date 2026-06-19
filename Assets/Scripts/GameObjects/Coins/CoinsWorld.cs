using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace GameObjects.Coins
{
    public sealed class CoinsWorld : IInitializable, IDisposable
    {
        private CoinPool _coinPool;
        private IWorldBounds _worldBounds;
        private IDifficulty _difficulty;
        private ISnake _snake;

        private List<Coin> _coins = new();

        public event Action<ICoin> OnCoinRemoved;
        public event Action OnAllCoinsEaten;

        [Inject]
        private void Construct(CoinPool coinPool, IWorldBounds worldBounds, IDifficulty difficulty, ISnake snake)
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
            _difficulty = difficulty;
            _snake = snake;
        }

        public bool TryRemoveCoin(Vector2Int position)
        {
            foreach (Coin coin in _coins)
            {
                if (coin.Position != position)
                    continue;

                OnCoinRemoved?.Invoke(coin);
                _coinPool.Despawn(coin);
                _coins.Remove(coin);

                if (_coins.Count == 0)
                    OnAllCoinsEaten?.Invoke();

                return true;
            }

            return false;
        }

        private void LevelChanged()
        {
            for (int i = 0; i < _difficulty.Current; i++)
                SpawnCoin();
        }

        private void SpawnCoin()
        {
            while (true)
            {
                Vector2Int position = _worldBounds.GetRandomPosition();

                if (IsPositionOccupied(position))
                    continue;

                Coin coin = _coinPool.Spawn(position);
                _coins.Add(coin);

                return;
            }
        }
        
        private bool IsPositionOccupied(Vector2Int position)
        {
            if (_snake.HeadPosition == position)
                return true;

            foreach (Coin coin in _coins)
                if (coin.Position == position)
                    return true;

            return false;
        }

        public void Initialize() =>
            _difficulty.OnStateChanged += LevelChanged;

        public void Dispose() =>
            _difficulty.OnStateChanged -= LevelChanged;
    }
}