using MobileClock.Mapper.Interface;
using MobileClock.Models;
using System;

namespace MobileClock.Mapper
{
    public class ClockModelMapper : IClockModelMapper
    {
        public ClockModel MapSingle()
            => new ClockModel(DateTime.Now.Ticks);
    }
}
