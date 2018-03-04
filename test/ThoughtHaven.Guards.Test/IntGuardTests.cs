using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class IntGuardTests
    {
        public class LessThanMethod
        {
            public class ParamNameAndIntValueAndMinimumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    int value = 1;
                    int minimum = 0;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: null, value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    int value = 1;
                    int minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: "", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    int value = 1;
                    int minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: " ", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    int value = -1;
                    int minimum = 0;

                    var exception = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.LessThan(nameof(value), value, minimum);
                    });

                    Assert.Equal("Value of -1 is less than minimum value 0.\r\nParameter name: value",
                        exception.Message);
                }

                [Fact]
                public void ValueAboveMinimum_ReturnsValue()
                {
                    int value = 1;
                    int minimum = 0;

                    int result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    int value = 1;
                    int minimum = 1;

                    int result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class GreaterThanMethod
        {
            public class ParamNameAndIntValueAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    int value = 1;
                    int maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: null, value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    int value = 1;
                    int maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: "", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    int value = 1;
                    int maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: " ", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    int value = 3;
                    int maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.GreaterThan(nameof(value), value, maximum);
                    });
                }

                [Fact]
                public void ValueBelowMaximum_ReturnsValue()
                {
                    int value = 1;
                    int maximum = 2;

                    int result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    int value = 1;
                    int maximum = 1;

                    int result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class OutOfRangeMethod
        {
            public class ParamNameAndIntValueAndMinimumAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    int value = 1;
                    int minimum = 0;
                    int maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: null, value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    int value = 1;
                    int minimum = 0;
                    int maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: "", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    int value = 1;
                    int minimum = 0;
                    int maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: " ", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    int value = -1;
                    int minimum = 0;
                    int maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    int value = 3;
                    int minimum = 0;
                    int maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueBetweenMinimumAndMaximum_ReturnsValue()
                {
                    int value = 1;
                    int minimum = 0;
                    int maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    int value = 0;
                    int minimum = 0;
                    int maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    int value = 2;
                    int minimum = 0;
                    int maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}