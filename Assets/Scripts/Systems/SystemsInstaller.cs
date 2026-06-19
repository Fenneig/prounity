using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private WorldBounds _worldBounds;
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private int _maxLevel;

        public override void InstallBindings()
        {
            Container
                .Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromInstance(_worldBounds)
                .AsSingle();

            Container
                .Bind<GameCycle>()
                .FromInstance(_gameCycle)
                .AsSingle();
            
            Container
                .Bind<IDifficulty>()
                .To<Difficulty>()
                .FromNew()
                .AsSingle()
                .WithArguments(_maxLevel);
        }
    }
}