using System;
using GameObjects.Coins;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class GameCycle : MonoBehaviour
    {
        private CoinsWorld _coinsWorld;
        private IDifficulty _difficulty;
        private ISnake _snake;
        private IWorldBounds _worldBounds;
        private IScore _score;

        public event Action<bool> OnGameEnded; 

        [Inject]
        public void Construct(CoinsWorld coinsWorld, IDifficulty difficulty, ISnake snake, IWorldBounds worldBounds, IScore score)
        {
            _coinsWorld = coinsWorld;
            _difficulty = difficulty;
            _snake = snake;
            _worldBounds = worldBounds;
            _score = score;
        }
    
        private void Awake()
        {
            _coinsWorld.OnCoinRemoved += CountScore;
            _coinsWorld.OnAllCoinsEaten += StartLevel;
            _snake.OnSelfCollided += Lose;
            _snake.OnMoved += HandleSnakeMove;
        }

        private void CountScore(ICoin coin) => 
            _score.Add(coin.Score);

        private void OnDestroy()
        {
            _coinsWorld.OnAllCoinsEaten -= StartLevel;
            _snake.OnSelfCollided -= Lose;
            _snake.OnMoved -= HandleSnakeMove;
        }

        private void Lose() => 
            GameOver(false);

        private void GameOver(bool win)
        {
            _snake.SetActive(false);
            OnGameEnded?.Invoke(win);
        }

        private void HandleSnakeMove(Vector2Int newPosition)
        {
            if (!_worldBounds.IsInBounds(newPosition))
            {
                Lose();
                return;
            }
        
            _coinsWorld.TryRemoveCoin(newPosition);
        }

        private void StartLevel()
        {
            if (_difficulty.Current == _difficulty.Max)
                GameOver(true);
            else
                _difficulty.Next(out int _);
        }

        private void Start()
        {
            StartLevel();
            _snake.SetActive(true);
        }
    }
}