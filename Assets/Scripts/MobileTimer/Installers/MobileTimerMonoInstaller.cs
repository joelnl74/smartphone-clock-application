using MobileClock.Mapper;
using MobileClock.Mapper.Interface;
using MobileClock.Presenter;
using MobileClock.Presenter.Interfaces;
using Zenject;

namespace MobileClock.Installer
{
    public class MobileTimerMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Signal bus.
            SignalBusInstaller.Install(Container);

            // Presenters.
            Container.Bind<IClockPresenter>().To<ClockPresenter>().AsSingle();
            Container.Bind<ITimerPresenter>().To<TimerPresenter>().AsSingle();
            Container.Bind<IStopWatchPresenter>().To<StopWatchPresenter>().AsSingle();

            // Mappers.
            Container.Bind<IClockModelMapper>().To<ClockModelMapper>().AsSingle();
            Container.Bind<ITimerModelMapper>().To<TimerModelMapper>().AsSingle();
            Container.Bind<ITimerLapModelMapper>().To<TimerLapModelMapper>().AsSingle();
        }
    }
}
