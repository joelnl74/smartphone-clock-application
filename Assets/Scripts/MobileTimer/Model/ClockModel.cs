using System;

namespace MobileClock.Models
{
    public class ClockModel : IEquatable<ClockModel>
    {
        public DateTime currentDateTime;

        public bool Equals(ClockModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return currentDateTime.Ticks == other.currentDateTime.Ticks;
        }
    }
}
