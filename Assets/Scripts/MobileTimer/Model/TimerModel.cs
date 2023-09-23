using System;

namespace MobileClock.Models
{
    public class TimerModel : IEquatable<TimerModel>
    {
        public TimeSpan timeSpan;

        public bool Equals(TimerModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return timeSpan == other.timeSpan;
        }
    }
}
