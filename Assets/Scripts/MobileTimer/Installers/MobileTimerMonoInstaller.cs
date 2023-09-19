using MobileClock.Mapper;
using MobileClock.Mapper.Interface;
using MobileClock.Presenter;
using MobileClock.Presenter.Interfaces;
using Zenject;

public class MobileTimerMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Presenters.
        Container.Bind<IClockPresenter>().To<ClockPresenter>().AsSingle();

        // Mappers.
        Container.Bind<IClockModelMapper>().To<ClockModelMapper>().AsSingle();
    }
}