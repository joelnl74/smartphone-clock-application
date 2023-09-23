using Zenject;
using Core.UI.Presenter.Interfaces;
using Core.UI.Presenter;

namespace Core.Installers
{
    public class MainMonoInstallerTests : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Signal bus.
            SignalBusInstaller.Install(Container);

            // Presenters.
            Container.Bind<IMainUIPresenter>().To<MainUIPresenter>().AsSingle();
        }
    }
}
