using System;

namespace MobileClock.Models
{
    public class ClockModel : IEquatable<ClockModel>
    {
        public long TimeStamp;

        public bool Equals(ClockModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TimeStamp == other.TimeStamp;
        }
    }
}
