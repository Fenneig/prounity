using Zenject;

namespace Game.Gameplay
{
    public class SaveSystemInstaller : MonoInstaller
    {
        //Для онлайн проекта ключ лучше хранить на сервере, но для локального и так достаточно 
        private const string SAVE_HMAC_KEY =
            "3vY8KqL2nW7xR5mJ9cF1uH6pT0aZ4sD8eG2bN7wQ5kI=";
        
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
                .To<HmacSha256Provider>()
                .AsSingle()
                .WithArguments(SAVE_HMAC_KEY);

            Container
                .BindInterfacesAndSelfTo<VersionProvider>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<ISaveSerializer>()
                .To<SaveSerializer>()
                .AsCached();
        }        
    }
}