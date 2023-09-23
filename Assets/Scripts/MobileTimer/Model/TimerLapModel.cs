using System;

namespace MobileClock.Models
{ 
    public class TimerLapModel : IEquatable<TimerLapModel>
    {
        public TimeSpan lapTimeSpan;
        public TimeSpan globalTimeSpan;

        public bool Equals(TimerLapModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return lapTimeSpan == other.lapTimeSpan 
                && globalTimeSpan == other.globalTimeSpan;
        }
    }
}
