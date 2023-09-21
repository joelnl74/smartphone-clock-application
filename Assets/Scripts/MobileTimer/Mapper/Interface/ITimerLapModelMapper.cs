using MobileClock.Models;
using System.Collections.Generic;

namespace MobileClock.Mapper.Interface
{
    public interface ITimerLapModelMapper
    {
        TimerLapModel MapSingle(TimerModel timerModel, List<TimerLapModel> timerLapModels);
    }
}
