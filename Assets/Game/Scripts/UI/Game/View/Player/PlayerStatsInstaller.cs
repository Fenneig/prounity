using System;
using UnityEngine;

namespace Game.UI
{
    [Serializable]
    public sealed class PlayerStatsInstaller : IGameUIInstaller
    {
        [SerializeField] private StatView _ammoView;
        [SerializeField] private StatView _healthView;
        [SerializeField] private ScoreView _scoreView;
        
        public void Install(IGameUI entity)
        {
            entity.AddAmmoView(_ammoView);
            entity.AddHealthView(_healthView);
            entity.AddScoreView(_scoreView);
        }
    }
}