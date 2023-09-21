using MobileClock.View.Interfaces;

namespace MobileClock.Presenter.Interfaces
{
    public interface IStopWatchPresenter : IBaseTimerPresenter<IStopWatchView>
    {
        void SetLapTime();
        void Reset();
    }
}

