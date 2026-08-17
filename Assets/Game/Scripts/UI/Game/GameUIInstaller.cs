using Atomic.Entities;
using UnityEngine;

namespace Game.UI
{
    public class GameUIInstaller : SceneEntityInstaller<IGameUI>
    {
        [SerializeField] private InputInstaller _inputInstaller;
        
        public override void Install(IGameUI entity)
        {
            _inputInstaller.Install(entity);
        }
    }
}