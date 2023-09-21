using MobileClock.Mapper.Interface;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;
using UnityEngine;

namespace MobileClock.Presenter
{
    public class StopWatchPresenter : BaseTimerPresenter<IStopWatchView>,
        IStopWatchPresenter
    {
        public StopWatchPresenter(ITimerModelMapper timerModelMapper) : base(timerModelMapper)
        {
        }

        public override void UpdateTimer()
        {
            timerModel.Time += Time.deltaTime;
            _view.DidLoadData(timerModel);
        }
    }
}

