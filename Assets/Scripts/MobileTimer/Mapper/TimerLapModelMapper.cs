using MobileClock.Mapper.Interface;
using MobileClock.Models;
using System.Collections.Generic;
using System.Linq;

namespace MobileClock.Mapper
{
    public class TimerLapModelMapper : ITimerLapModelMapper
    {
        public TimerLapModel MapSingle(TimerModel timerModel, List<TimerLapModel> timerLapModels)
        {
            var lastLapModel = timerLapModels.Count > 0 ? timerLapModels.Last() : null;

            if (lastLapModel == null)
            {
                return new TimerLapModel
                {
                    globalTimeSpan = timerModel.timeSpan,
                    lapTimeSpan = timerModel.timeSpan
                };
            }

            return new TimerLapModel
            {
                globalTimeSpan = timerModel.timeSpan,
                lapTimeSpan = timerModel.timeSpan - lastLapModel.globalTimeSpan
            };
        }
    }
}
