using MobileClock.Mapper.Interface;
using MobileClock.Models;

namespace MobileClock.Mapper
{
    public class TimerModelMapper : ITimerModelMapper
    {
        public TimerModel MapSingle(float time = 0)
            => new TimerModel { Time = time };
    }
}
