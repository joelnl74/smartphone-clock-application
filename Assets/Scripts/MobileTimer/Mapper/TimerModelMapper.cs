using MobileClock.Mapper.Interface;
using MobileClock.Models;

namespace MobileClock.Mapper
{
    public class TimerModelMapper : ITimerModelMapper
    {
        public TimerModel MapSingle(int time = 0)
            => new TimerModel { timeSpan = new System.TimeSpan(0, 0, time) };
    }
}
