using System;

namespace ThoughtHaven
{
    public class SystemClock
    {
        public virtual UtcDateTime UtcNow => new UtcDateTime(DateTimeOffset.UtcNow);
    }
}