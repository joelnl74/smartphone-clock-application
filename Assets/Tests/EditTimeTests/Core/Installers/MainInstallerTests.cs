using NUnit.Framework;
using Zenject;
using Core.UI.Presenter.Interfaces;
using Core.UI.Presenter;

namespace Tests.Core.Installer
{
    [TestFixture]
    public class MainMonoInstallerTests : ZenjectUnitTestFixture
    {
        [Test]
        public void Bindings_ShouldContainTimerPresenter()
        {
            //Arange.
            Container.Bind<IMainUIPresenter>().To<MainUIPresenter>().AsSingle();

            //Act.
            var mainUIPresenter = Container.Resolve<IMainUIPresenter>();

            //Assert.
            Assert.NotNull(mainUIPresenter);
        }

        [Test]
        public void Bindings_ShouldContainSignalBus()
        {
            // Arrange.
            SignalBusInstaller.Install(Container);
            Container.Inject(this);

            // Act.
            var signalBus = Container.Resolve<SignalBus>();

            // Assert.
            Assert.NotNull(signalBus);
        }
    }
}
