using MobileClock.Mapper;
using MobileClock.Mapper.Interface;
using MobileClock.Presenter;
using MobileClock.Presenter.Interfaces;
using NUnit.Framework;
using Zenject;

namespace Tests.MobileTimer.Installer
{
    [TestFixture]
    public class MobileTimerMonoInstallerTests : ZenjectUnitTestFixture
    {
        [Test]
        public void Bindings_ShouldContainTimerPresenter()
        {
            //Arange.
            SignalBusInstaller.Install(Container);
            Container.Bind<ITimerModelMapper>().To<TimerModelMapper>().AsSingle();
            Container.Bind<ITimerPresenter>().To<TimerPresenter>().AsSingle();

            //Act.
            var timerPresenter = Container.Resolve<ITimerPresenter>();

            //Assert.
            Assert.NotNull(timerPresenter);
        }

        [Test]
        public void Bindings_ShouldContainClockPresenter()
        {
            //Arange.
            Container.Bind<IClockModelMapper>().To<ClockModelMapper>().AsSingle();
            Container.Bind<IClockPresenter>().To<ClockPresenter>().AsSingle();

            //Act.
            var clockPresenter = Container.Resolve<IClockPresenter>();

            //Assert.
            Assert.NotNull(clockPresenter);
        }

        [Test]
        public void Bindings_ShouldContainStopWatchPresenter()
        {
            //Arange.
            Container.Bind<ITimerModelMapper>().To<TimerModelMapper>().AsSingle();
            Container.Bind<ITimerLapModelMapper>().To<TimerLapModelMapper>().AsSingle();
            Container.Bind<IStopWatchPresenter>().To<StopWatchPresenter>().AsSingle();

            //Act.
            var stopWatchPresenter = Container.Resolve<IStopWatchPresenter>();

            //Assert.
            Assert.NotNull(stopWatchPresenter);
        }

        [Test]
        public void Bindings_ShouldContainLapModelMapper()
        {
            //Arange.
            Container.Bind<ITimerLapModelMapper>().To<TimerLapModelMapper>().AsSingle();

            //Act.
            var timerLapModelMapper = Container.Resolve<ITimerLapModelMapper>();

            //Assert.
            Assert.NotNull(timerLapModelMapper);
        }

        [Test]
        public void Bindings_ShouldContainTimeModelMapper()
        {
            //Arange.
            Container.Bind<ITimerModelMapper>().To<TimerModelMapper>().AsSingle();

            //Act.
            var timerModelMapper = Container.Resolve<ITimerModelMapper>();

            //Assert.
            Assert.NotNull(timerModelMapper);
        }

        [Test]
        public void Bindings_ShouldContainClockModelMapper()
        {
            //Arange.
            Container.Bind<IClockModelMapper>().To<ClockModelMapper>().AsSingle();

            //Act.
            var clockModelMapper = Container.Resolve<IClockModelMapper>();

            //Assert.
            Assert.NotNull(clockModelMapper);
        }
    }
}
