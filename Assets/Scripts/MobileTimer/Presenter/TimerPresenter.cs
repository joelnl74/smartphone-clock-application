using Core.Presenter;
using MobileClock.Mapper.Interface;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;

namespace MobileClock.Presenter
{
    public class TimerPresenter : BaseTimerPresenter<ITimerView>,
        ITimerPresenter
    {
        public TimerPresenter(ITimerModelMapper timerModelMapper) : base(timerModelMapper)
        {
        }

        public void SetTimer(float time)
        {
        }
    }
}

