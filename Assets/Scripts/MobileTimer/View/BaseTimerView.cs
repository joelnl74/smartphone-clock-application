using Core.View;
using MobileClock.Models;
using MobileClock.View.Interfaces;

namespace MobileClock.View
{
    public class BaseTimerView : BaseView
    , IBaseTimerView
    {
        public void DidLoadData(TimerModel timerModel)
        {
        }

        public void DidReset()
        {
        }

        public void DidStop()
        {
        }
    }
}
