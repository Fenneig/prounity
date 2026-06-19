using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Ui
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField] private GameUI _gameUI;

        public override void InstallBindings()
        {
            Container
                .Bind<IGameUI>()
                .To<GameUI>()
                .FromInstance(_gameUI)
                .AsSingle();
            
            Container
                .Bind<IScore>()
                .To<Score>()
                .FromNew()
                .AsSingle();
        }
    }
}