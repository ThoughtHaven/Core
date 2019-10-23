using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class ShortGuardTests
    {
        public class LessThanMethod
        {
            public class ParamNameAndShortValueAndMinimumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    short value = 1;
                    short minimum = 0;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: null!, value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    short value = 1;
                    short minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: "", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    short value = 1;
                    short minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: " ", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    short value = -1;
                    short minimum = 0;

                    var exception = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.LessThan(nameof(value), value, minimum);
                    });

                    Assert.Equal("Value of -1 is less than minimum value 0. (Parameter 'value')",
                        exception.Message);
                }

                [Fact]
                public void ValueAboveMinimum_ReturnsValue()
                {
                    short value = 1;
                    short minimum = 0;

                    short result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    short value = 1;
                    short minimum = 1;

                    short result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class GreaterThanMethod
        {
            public class ParamNameAndShortValueAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    short value = 1;
                    short maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: null!, value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    short value = 1;
                    short maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: "", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    short value = 1;
                    short maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: " ", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    short value = 3;
                    short maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.GreaterThan(nameof(value), value, maximum);
                    });
                }

                [Fact]
                public void ValueBelowMaximum_ReturnsValue()
                {
                    short value = 1;
                    short maximum = 2;

                    short result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    short value = 1;
                    short maximum = 1;

                    short result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class OutOfRangeMethod
        {
            public class ParamNameAndShortValueAndMinimumAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    short value = 1;
                    short minimum = 0;
                    short maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: null!, value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    short value = 1;
                    short minimum = 0;
                    short maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: "", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    short value = 1;
                    short minimum = 0;
                    short maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: " ", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    short  value = -1;
                    short  minimum = 0;
                    short  maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    short value = 3;
                    short minimum = 0;
                    short maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueBetweenMinimumAndMaximum_ReturnsValue()
                {
                    short value = 1;
                    short minimum = 0;
                    short maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    short value = 0;
                    short minimum = 0;
                    short maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    short value = 2;
                    short minimum = 0;
                    short maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}