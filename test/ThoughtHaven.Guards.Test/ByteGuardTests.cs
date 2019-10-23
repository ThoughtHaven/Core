using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class ByteGuardTests
    {
        public class LessThanMethod
        {
            public class ParamNameAndByteValueAndMinimumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    byte value = 1;
                    byte minimum = 0;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: null!, value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    byte value = 1;
                    byte minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: "", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    byte value = 1;
                    byte minimum = 0;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.LessThan(paramName: " ", value: value, minimum: minimum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    byte value = 0;
                    byte minimum = 1;

                    var exception = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.LessThan(nameof(value), value, minimum);
                    });

                    Assert.Equal("Value of 0 is less than minimum value 1. (Parameter 'value')",
                        exception.Message);
                }

                [Fact]
                public void ValueAboveMinimum_ReturnsValue()
                {
                    byte value = 1;
                    byte minimum = 0;

                    byte result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    byte value = 1;
                    byte minimum = 1;

                    byte result = Guard.LessThan(nameof(value), value, minimum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class GreaterThanMethod
        {
            public class ParamNameAndByteValueAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    byte value = 1;
                    byte maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: null!, value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    byte value = 1;
                    byte maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: "", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    byte value = 1;
                    byte maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.GreaterThan(paramName: " ", value: value, maximum: maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    byte value = 3;
                    byte maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.GreaterThan(nameof(value), value, maximum);
                    });
                }

                [Fact]
                public void ValueBelowMaximum_ReturnsValue()
                {
                    byte value = 1;
                    byte maximum = 2;

                    byte result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    byte value = 1;
                    byte maximum = 1;

                    byte result = Guard.GreaterThan(nameof(value), value, maximum);

                    Assert.Equal(value, result);
                }
            }
        }

        public class OutOfRangeMethod
        {
            public class ParamNameAndByteValueAndMinimumAndMaximumOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    byte value = 1;
                    byte minimum = 0;
                    byte maximum = 2;

                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: null!, value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    byte value = 1;
                    byte minimum = 0;
                    byte maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: "", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    byte value = 1;
                    byte minimum = 0;
                    byte maximum = 2;

                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.OutOfRange(paramName: " ", value: value, minimum: minimum,
                            maximum: maximum);
                    });
                }

                [Fact]
                public void ValueBelowMinimum_Throws()
                {
                    byte value = 0;
                    byte minimum = 1;
                    byte maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueAboveMaximum_Throws()
                {
                    byte value = 3;
                    byte minimum = 0;
                    byte maximum = 2;

                    Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
                    {
                        Guard.OutOfRange(nameof(value), value, minimum, maximum);
                    });
                }

                [Fact]
                public void ValueBetweenMinimumAndMaximum_ReturnsValue()
                {
                    byte value = 1;
                    byte minimum = 0;
                    byte maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMinimum_ReturnsValue()
                {
                    byte value = 0;
                    byte minimum = 0;
                    byte maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void ValueEqualToMaximum_ReturnsValue()
                {
                    byte value = 2;
                    byte minimum = 0;
                    byte maximum = 2;

                    var result = Guard.OutOfRange(nameof(value), value, minimum, maximum);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}