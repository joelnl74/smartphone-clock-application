using Core.View;
using MobileClock.Models;
using MobileClock.View.Interfaces;

namespace MobileClock.View
{
    public class TimerView : BaseTimerView
        ,ITimerView
    {
        public void DidSetTimer(TimerModel timerModel)
        {
        }
    }
}
