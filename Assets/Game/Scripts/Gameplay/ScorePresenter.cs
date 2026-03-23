using Game.Ships;
using Modules.UI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private ShipsWorld _shipsWorld;
        [SerializeField] private ScoreView _scoreView;
        
        private int _score = 0;

        private void UpdateScore() => 
            _scoreView.SetValue(++_score);

        private void Awake()
        {
            _shipsWorld.OnEnemyDied += UpdateScore;
            _scoreView.SetValue(0);
        }

        private void OnDestroy()
        {
            _shipsWorld.OnEnemyDied -= UpdateScore;
        }
    }
}