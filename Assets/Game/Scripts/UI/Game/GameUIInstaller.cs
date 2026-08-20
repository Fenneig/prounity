using Atomic.Entities;
using UnityEngine;

namespace Game.UI
{
    public class GameUIInstaller : SceneEntityInstaller<IGameUI>
    {
        [SerializeField] private InputInstaller _inputInstaller;
        [SerializeField] private PlayerStatsInstaller _playerStatsInstaller;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private HealthScreenView _healthScreenView;
        
        public override void Install(IGameUI entity)
        {
            _inputInstaller.Install(entity);
            _playerStatsInstaller.Install(entity);
            entity.AddScoreView(_scoreView);
            entity.AddHealthScreenView(_healthScreenView);
        }
    }
}