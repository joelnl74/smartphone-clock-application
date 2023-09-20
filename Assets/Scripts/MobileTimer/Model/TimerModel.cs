using System;

namespace MobileClock.Models
{
    public class TimerModel : IEquatable<TimerModel>
    {
        public float Time { get; private set; }

        public TimerModel(float time)
            => Time = time;

        public bool Equals(TimerModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Time == other.Time;
        }
    }
}
