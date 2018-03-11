using System;
using Xunit;

namespace ThoughtHaven
{
    public class SystemClockTests
    {
        public class UtcNowProperty
        {
            public class GetAccessor
            {
                [Fact]
                public void WhenCalled_ReturnsCurrent()
                {
                    var systemClock = new SystemClock();

                    var expected = DateTimeOffset.UtcNow;
                    var actual = systemClock.UtcNow;

                    Assert.True(expected <= actual);
                }

                [Fact]
                public void WhenCalled_ReturnsNotDefault()
                {
                    var systemClock = new SystemClock();

                    var result = systemClock.UtcNow;

                    Assert.NotEqual(default(DateTimeOffset), result);
                }
            }
        }
    }
}