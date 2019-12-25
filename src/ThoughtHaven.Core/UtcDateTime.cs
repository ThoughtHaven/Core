using System;

namespace ThoughtHaven
{
    public class UtcDateTime
    {
        public long Ticks { get; }

        protected DateTimeOffset Offset { get; }
        public DayOfWeek DayOfWeek => this.Offset.DayOfWeek;
        public int Year => this.Offset.Year;
        public int Month => this.Offset.Month;
        public int Day => this.Offset.Day;
        public int Hour => this.Offset.Hour;
        public int Minute => this.Offset.Minute;

        public UtcDateTime(DateTimeOffset dateTime) : this(dateTime.UtcTicks) { }

        public UtcDateTime(long ticks)
        {
            this.Ticks = Guard.LessThan(nameof(ticks), ticks, minimum: 0);
            this.Offset = new DateTimeOffset(this.Ticks, TimeSpan.Zero);
        }

        public DateTimeOffset ToOffset() => new DateTimeOffset(this.Ticks, TimeSpan.Zero);

        public static implicit operator UtcDateTime(DateTimeOffset dateTime) =>
            new UtcDateTime(dateTime);

        public static implicit operator DateTimeOffset(UtcDateTime dateTime) =>
            dateTime.Offset;
    }
}