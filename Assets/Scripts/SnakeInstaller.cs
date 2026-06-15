using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

public class SnakeInstaller : MonoInstaller
{
    [SerializeField] private WorldBounds _worldBounds;
    [SerializeField] private Snake _snake;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinContainer;
    
    public override void InstallBindings()
    {
        Container.Bind<ISnake>().To<Snake>().FromInstance(_snake);
        
        Container.Bind<IWorldBounds>().To<WorldBounds>().FromInstance(_worldBounds);
        
        Container
            .BindMemoryPool<Coin, CoinPool>()
            .FromComponentInNewPrefab(_coinPrefab)
            .UnderTransform(_coinContainer)
            .AsSingle();
    }
}