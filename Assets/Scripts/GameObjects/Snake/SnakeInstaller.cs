using Modules;
using UnityEngine;
using Zenject;

namespace GameObjects.Snake
{
    public sealed class SnakeInstaller : MonoInstaller
    {
        [SerializeField] private Modules.Snake _snake;
    
        public override void InstallBindings()
        {
            Container
                .Bind<ISnake>()
                .To<Modules.Snake>()
                .FromInstance(_snake)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<SnakeController>()
                .FromNew()
                .AsSingle();
        }
    }
}