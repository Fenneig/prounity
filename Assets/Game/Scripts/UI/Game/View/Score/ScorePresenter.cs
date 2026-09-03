using Atomic.Elements;

namespace Game.UI
{
    public class ScorePresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameContext _context;
        
        private ScoreView _scoreView;
        private IReactiveVariable<int> _score;
        private Subscription<int> _subscription;

        public ScorePresenter(IGameContext context)
        {
            _context = context;
        }

        public void Init(IGameUI entity)
        {
            _scoreView = entity.GetScoreView();
            _score = _context.GetScore();
            
            _subscription = _score.Observe(UpdateScore);
        }

        private void UpdateScore(int newValue)
        {
            _scoreView.SetScore(newValue.ToString());
        }

        public void Dispose(IGameUI entity)
        {
            _subscription.Dispose();
        }
    }
}