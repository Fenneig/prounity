using Zenject;

namespace Game.Gameplay
{
    public class SaveSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<SaveManager>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<ISaveSerializer>()
                .To<EntitySaveSerializer>()
                .AsCached();
            
            Container
                .Bind<ResolveContext>()
                .FromNew()
                .AsSingle();
        }        
    }
}