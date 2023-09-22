using MobileClock.Models;

namespace MobileClock.Mapper.Interface
{
    public interface ITimerModelMapper
    {
        TimerModel MapSingle(int time = 0);
    }
}
