using Modules;
using SnakeGame;
using Systems;
using UnityEngine;
using Zenject;

namespace Ui
{
    public sealed class GameUIPresenter : MonoBehaviour
    {
        private IGameUI _gameUI;
        private IScore _score;
        private IDifficulty _difficulty;
        private GameCycle _gameCycle;

        [Inject]
        public void Construct(IGameUI gameUI, IScore score, IDifficulty difficulty, GameCycle gameCycle)
        {
            _gameUI = gameUI;
            _score = score;
            _difficulty = difficulty;
            _gameCycle = gameCycle;
        }

        private void Start()
        {
            _score.OnStateChanged += UpdateScore;
            _difficulty.OnStateChanged += UpdateLevel;
            _gameCycle.OnGameEnded += ShowGameOver;

            UpdateScore(_score.Current);
            UpdateLevel();
        }

        private void UpdateLevel() => 
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);

        private void ShowGameOver(bool win) => 
            _gameUI.GameOver(win);

        private void UpdateScore(int newScore) => 
            _gameUI.SetScore(newScore.ToString());

        private void OnDestroy()
        {
            _score.OnStateChanged -= UpdateScore;
            _difficulty.OnStateChanged -= UpdateLevel;
            _gameCycle.OnGameEnded -= ShowGameOver;
        }
    }
}