using System;
using Xunit;

namespace ThoughtHaven
{
    public class SystemClockTests
    {
        public class UtcNowProperty
        {
            [Fact]
            public void Get_ReturnsCurrent()
            {
                var systemClock = new SystemClock();

                var expected = DateTimeOffset.UtcNow;
                var actual = systemClock.UtcNow;

                Assert.True(expected <= actual);
            }

            [Fact]
            public void Get_ReturnsNotDefault()
            {
                var systemClock = new SystemClock();

                var result = systemClock.UtcNow;

                Assert.NotEqual(default(DateTimeOffset), result);
            }
        }
    }
}