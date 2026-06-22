using Modules;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class SnakeInstaller : MonoInstaller
    {
        [SerializeField] private Snake _snake;
    
        public override void InstallBindings()
        {
            Container
                .Bind<ISnake>()
                .To<Snake>()
                .FromInstance(_snake)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<SnakeController>()
                .FromNew()
                .AsSingle();
        }
    }
}