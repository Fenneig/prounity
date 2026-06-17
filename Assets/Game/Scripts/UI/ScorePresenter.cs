using Modules.UI;
using UnityEngine;

namespace Game.UI
{
    public sealed class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;
        
        private int _score = 0;

        public void SetScore(int amount)
        {
            _score = amount;
            _scoreView.SetValue(_score);
        }
        
        public void CountScore() => 
            _scoreView.SetValue(++_score);

        private void Awake() => 
            SetScore(0);
    }
}