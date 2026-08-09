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
                .Bind<EntitySaveSerializer>()
                .FromNew()
                .AsSingle();
            
            Container
                .Bind<IHashProvider>()
                .To<Sha256Provider>().AsSingle();

            Container
                .Bind<VersionController>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<ISaveSerializer>()
                .To<SaveSerializer>()
                .AsCached();
        }        
    }
}