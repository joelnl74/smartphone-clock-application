using MobileClock.Mapper.Interface;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;

namespace MobileClock.Presenter
{
    public class StopWatchPresenter : BaseTimerPresenter<IStopWatchView>,
        IStopWatchPresenter
    {
        public StopWatchPresenter(ITimerModelMapper timerModelMapper) : base(timerModelMapper)
        {
        }
    }
}

