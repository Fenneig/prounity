using Zenject;

namespace Game.Presentation
{
    public class PresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IControlsPresenter>()
                .To<ControlPresenter>()
                .FromNew()
                .AsSingle();
        }
    }
}