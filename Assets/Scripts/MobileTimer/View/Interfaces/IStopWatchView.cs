using MobileClock.Models;

namespace MobileClock.View.Interfaces
{
    public interface IStopWatchView : IBaseTimerView
    {
        void DidUpdateLapTime(TimerLapModel model);
        void DidReset();
    }
}
