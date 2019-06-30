using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class DoubleGuardTests
    {
        public class LessThanMethod
        {
            public class ParamNameAndDoubleValueAndMinimumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    double value = 1;
                    double minimum = 0;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: null!, value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    double value = 1;
                    double minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: "", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    double value = 1;
                    double minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: " ", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    double value = -1;
                    double minimum = 0;

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
                    double value = 1;
                    double minimum = 0;

                    double result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    double value = 1;
                    double minimum = 1;

                    double result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class GreaterThanMethod
        {
            public class ParamNameAndDoubleValueAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    double value = 1;
                    double maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: null!, value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    double value = 1;
                    double maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: "", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    double value = 1;
                    double maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: " ", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    double value = 3;
                    double maximum = 2;

                    var exception = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.GreaterThan(nameof(value), value, maximum);
                    });

                    Assert.Equal("Value of 3 is greater than maximum value 2.\r\nParameter name: value",
                        exception.Message);
                }

                [Fact]
                public void ValueBelowMaximum_ReturnsValue()
                {
                    double value = 1;
                    double maximum = 2;

                    double result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    double value = 2;
                    double maximum = 2;

                    double result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class OutOfRangeMethod
        {
            public class ParamNameAndDoubleValueAndMinimumAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    double value = 1;
                    double minimum = 0;
                    double maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: null!, value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    double value = 1;
                    double minimum = 0;
                    double maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: "", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    double value = 1;
                    double minimum = 0;
                    double maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: " ", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    double value = -1;
                    double minimum = 0;
                    double maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    double value = 3;
                    double minimum = 0;
                    double maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueBetweenMinimumAndMaximum_ReturnsValue()
                {
                    double value = 1;
                    double minimum = 0;
                    double maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    double value = 0;
                    double minimum = 0;
                    double maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    double value = 2;
                    double minimum = 0;
                    double maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}