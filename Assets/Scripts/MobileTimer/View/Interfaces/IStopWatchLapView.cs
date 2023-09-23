using MobileClock.Models;

namespace MobileClock.View.Interfaces
{
    public interface IStopWatchLapView
    {
        public void Add(TimerLapModel timerLapModel);
        public void Clear();
    }
}
