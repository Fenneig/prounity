using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private WorldBounds _worldBounds;
        [SerializeField] private int _maxLevel;

        public override void InstallBindings()
        {
            Container
                .Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromInstance(_worldBounds)
                .AsSingle();
            
            Container
                .Bind<IDifficulty>()
                .To<Difficulty>()
                .FromNew()
                .AsSingle()
                .WithArguments(_maxLevel);

            Container
                .Bind<IScore>()
                .To<Score>()
                .FromNew()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ScoreController>()
                .FromNew()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<LevelController>()
                .FromNew()
                .AsSingle();
            
            Container
                .Bind<GameState>()
                .FromNew()
                .AsSingle();
        }
    }
}