using Atomic.Entities;
using UnityEngine;

namespace Game.UI
{
    public class GameUIInstaller : SceneEntityInstaller<IGameUI>
    {
        [SerializeField] private InputInstaller _inputInstaller;
        [SerializeField] private PlayerStatsInstaller _playerStatsInstaller;
        [SerializeField] private HealthScreenView _healthScreenView;
        [SerializeField] private PlayerUIInstaller _playerUIInstaller;
        
        public override void Install(IGameUI entity)
        {
            _inputInstaller.Install(entity);
            _playerStatsInstaller.Install(entity);
            _playerUIInstaller.Install(entity);
            
            entity.AddHealthScreenView(_healthScreenView);
        }
    }
}