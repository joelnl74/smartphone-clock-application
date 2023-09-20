using MobileClock.Models;

namespace MobileClock.Mapper.Interface
{
    public interface ITimerModelMapper
    {
        TimerModel MapSingle(float time = 0);
    }
}
