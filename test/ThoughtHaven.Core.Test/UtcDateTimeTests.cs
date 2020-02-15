using System;
using Xunit;

namespace ThoughtHaven
{
    public class UtcDateTimeTests
    {
        public class DayOfWeekProperty
        {
            public class GetAccessor
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000_000)]
                public void WhenCalled_SetsDayOfWeek(long ticks)
                {
                    var offset = new DateTimeOffset(ticks, TimeSpan.Zero);
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(offset.DayOfWeek, utc.DayOfWeek);
                }
            }
        }

        public class YearProperty
        {
            public class GetAccessor
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000_000)]
                public void WhenCalled_SetsYear(long ticks)
                {
                    var offset = new DateTimeOffset(ticks, TimeSpan.Zero);
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(offset.Year, utc.Year);
                }
            }
        }

        public class MonthProperty
        {
            public class GetAccessor
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000_000)]
                public void WhenCalled_SetsMonth(long ticks)
                {
                    var offset = new DateTimeOffset(ticks, TimeSpan.Zero);
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(offset.Month, utc.Month);
                }
            }
        }

        public class DayProperty
        {
            public class GetAccessor
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000_000)]
                public void WhenCalled_SetsDay(long ticks)
                {
                    var offset = new DateTimeOffset(ticks, TimeSpan.Zero);
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(offset.Day, utc.Day);
                }
            }
        }

        public class HourProperty
        {
            public class GetAccessor
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000_000)]
                public void WhenCalled_SetsHour(long ticks)
                {
                    var offset = new DateTimeOffset(ticks, TimeSpan.Zero);
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(offset.Hour, utc.Hour);
                }
            }
        }

        public class MinuteProperty
        {
            public class GetAccessor
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000_000)]
                public void WhenCalled_SetsMinute(long ticks)
                {
                    var offset = new DateTimeOffset(ticks, TimeSpan.Zero);
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(offset.Minute, utc.Minute);
                }
            }
        }

        public class Constructor
        {
            public class DateTimeOverload
            {
                [Theory]
                [InlineData(1)]
                [InlineData(1_000_000)]
                public void WhenCalled_SetsTicks(long ticks)
                {
                    var dateTime = new DateTimeOffset(ticks, TimeSpan.Zero);

                    var utc = new UtcDateTime(dateTime);

                    Assert.Equal(dateTime.UtcTicks, utc.Ticks);
                }
            }

            public class TicksOverload
            {
                [Fact]
                public void TicksBelowZero_Throws()
                {
                    Assert.Throws<ArgumentOutOfRangeException>("ticks", () =>
                    {
                        new UtcDateTime(ticks: -1);
                    });
                }

                [Theory]
                [InlineData(1)]
                [InlineData(2)]
                public void WhenCalled_SetsTicks(long ticks)
                {
                    var utc = new UtcDateTime(ticks);

                    Assert.Equal(ticks, utc.Ticks);
                }
            }
        }

        public class ToOffsetMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void WhenCalled_ReturnsOffset()
                {
                    var offset = DateTimeOffset.UtcNow;
                    var utc = new UtcDateTime(offset.UtcTicks);

                    var result = utc.ToOffset();

                    Assert.Equal(offset, result);
                }
            }
        }
    }
}