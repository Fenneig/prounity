using Game.Systems.Enemies;
using Modules.UI;
using UnityEngine;

namespace Game.UI
{
    public sealed class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private EnemyDieMediator _enemyDieMediator;
        
        private int _score = 0;

        private void UpdateScore() => 
            _scoreView.SetValue(++_score);

        private void Awake()
        {
            _enemyDieMediator.OnEnemyDied += UpdateScore;
            _scoreView.SetValue(0);
        }

        private void OnDestroy()
        {
            _enemyDieMediator.OnEnemyDied -= UpdateScore;
        }
    }
}