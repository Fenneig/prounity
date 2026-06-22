using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class CoinsWorld
    {
        private CoinPool _coinPool;
        private IWorldBounds _worldBounds;
        private ISnake _snake;

        private List<Coin> _coins = new();

        public event Action<ICoin> OnCoinRemoved;
        public event Action OnAllCoinsRemoved;

        [Inject]
        private void Construct(
            CoinPool coinPool, 
            IWorldBounds worldBounds,
            ISnake snake)
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
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
                    OnAllCoinsRemoved?.Invoke();

                return true;
            }

            return false;
        }

        public bool TrySpawnCoin()
        {
            const int MAX_ATTEMPTS = 10;

            for (int i = 0; i < MAX_ATTEMPTS; i++)
            {
                Vector2Int position = _worldBounds.GetRandomPosition();

                if (IsPositionOccupied(position))
                    continue;

                Coin coin = _coinPool.Spawn(position);
                _coins.Add(coin);

                return true;
                
            }

            return false;
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
    }
}