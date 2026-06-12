using Game.Systems;
using Modules.UI;
using UnityEngine;

namespace Game.UI
{
    public sealed class GameOverPresenter : MonoBehaviour
    {
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private GameCycle _gameCycle;

        private void Awake() => _gameCycle.OnGameEnded += _gameOverView.Show;

        private void OnDestroy() => _gameCycle.OnGameEnded -= _gameOverView.Show;
    }
}