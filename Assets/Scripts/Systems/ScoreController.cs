using System;
using Modules;
using Zenject;

namespace Systems
{
    public sealed class ScoreController : IInitializable, IDisposable
    {
        private CoinsWorld _coinsWorld;
        private IScore _score;

        public ScoreController(CoinsWorld coinsWorld, IScore score)
        {
            _coinsWorld = coinsWorld;
            _score = score;
        }

        public void Initialize() => 
            _coinsWorld.OnCoinRemoved += CountScore;

        public void Dispose() => 
            _coinsWorld.OnCoinRemoved -= CountScore;

        private void CountScore(ICoin coin) => 
            _score.Add(coin.Score);
    }
}