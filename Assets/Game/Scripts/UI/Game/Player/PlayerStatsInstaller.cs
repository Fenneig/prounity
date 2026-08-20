using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.UI
{
    [Serializable]
    public sealed class PlayerStatsInstaller : IEntityInstaller<IGameUI>
    {
        [SerializeField] private StatView _ammoView;
        [SerializeField] private StatView _healthView;
        
        public void Install(IGameUI entity)
        {
            entity.AddAmmoView(_ammoView);
            entity.AddHealthView(_healthView);
        }
    }
}