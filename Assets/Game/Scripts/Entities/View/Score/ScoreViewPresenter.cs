using Atomic.Elements;
using Atomic.Entities;
using Game.UI;

namespace Game.Entities.Score
{
    public class ScoreViewPresenter : IEntityInit, IEntityDispose
    {
        private readonly GameUI _ui;
        private ScoreView _scoreView;
        private IReactiveVariable<int> _score;
        private Subscription<int> _subscription;

        public ScoreViewPresenter(GameUI ui)
        {
            _ui = ui;
        }

        public void Init(IEntity entity)
        {
            _scoreView = _ui.GetScoreView();
            _score = entity.GetScore();
            
            _subscription = _score.Observe(UpdateScore);
        }

        private void UpdateScore(int newValue)
        {
            _scoreView.SetScore(newValue.ToString());
        }

        public void Dispose(IEntity entity)
        {
            _subscription.Dispose();
        }
    }
}