using System;

namespace ThoughtHaven
{
    public class SystemClock
    {
        public virtual DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}