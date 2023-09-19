using MobileClock.Presenter;
using MobileClock.Presenter.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class MobileTimerMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IClockPresenter>().To<ClockPresenter>().AsSingle();
    }
}