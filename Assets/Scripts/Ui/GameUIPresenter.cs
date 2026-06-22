using System;
using Modules;
using SnakeGame;
using Systems;
using Zenject;

namespace Ui
{
    public sealed class GameUIPresenter : IInitializable, IDisposable
    {
        private IGameUI _gameUI;
        private IScore _score;
        private IDifficulty _difficulty;
        private GameState _gameState;

        public GameUIPresenter(IGameUI gameUI, IScore score, IDifficulty difficulty, GameState gameState)
        {
            _gameUI = gameUI;
            _score = score;
            _difficulty = difficulty;
            _gameState = gameState;
        }
        
        private void UpdateLevel() => 
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);

        private void ShowGameOver(bool win) => 
            _gameUI.GameOver(win);

        private void UpdateScore(int newScore) => 
            _gameUI.SetScore(newScore.ToString());
        
        public void Initialize()
        {
            _score.OnStateChanged += UpdateScore;
            _difficulty.OnStateChanged += UpdateLevel;
            _gameState.OnGameEnded += ShowGameOver;

            UpdateScore(_score.Current);
            UpdateLevel();
        }

        public void Dispose()
        {
            _score.OnStateChanged -= UpdateScore;
            _difficulty.OnStateChanged -= UpdateLevel;
            _gameState.OnGameEnded -= ShowGameOver;
        }
    }
}