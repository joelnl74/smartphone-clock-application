using MobileClock.Mapper.Interface;
using MobileClock.Models;
using System;

namespace MobileClock.Mapper
{
    public class ClockModelMapper : IClockModelMapper
    {
        public ClockModel MapSingle()
        {
            return new ClockModel(DateTime.Now.Ticks);
        }
    }
}
