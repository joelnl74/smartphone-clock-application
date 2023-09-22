using Core.Interfaces;
using MobileClock.Models;

namespace MobileClock.View.Interfaces
{
    public interface IBaseTimerView : IView
    {
        void DidLoadData(TimerModel timerModel);
        void DidStop();
        void DidStartTimer();
    }
}
