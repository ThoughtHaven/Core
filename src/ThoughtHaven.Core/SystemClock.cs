namespace ThoughtHaven
{
    public class SystemClock
    {
        public virtual UtcDateTime UtcNow => new UtcDateTime(System.DateTimeOffset.UtcNow);
    }
}