using Core.Interfaces;
using MobileClock.Models;

namespace MobileClock.View.Interfaces
{
    public interface ITimerView : IBaseTimerView
    {
        void DidSetTimer(TimerModel timerModel);
        void DidReset();
    }
}
