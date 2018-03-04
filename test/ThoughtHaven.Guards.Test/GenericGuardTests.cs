using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class GenericGuardTests
    {
        public class NullMethod
        {
            public class ParamNameAndValueOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    var exception = Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.Null(paramName: null, value: new object());
                    });

                    Assert.Equal("Value cannot be null.\r\nParameter name: paramName",
                        exception.Message);
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    var exception = Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.Null(paramName: "", value: new object());
                    });

                    Assert.Equal("Value cannot be empty.\r\nParameter name: paramName",
                        exception.Message);
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    var exception = Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.Null(paramName: " ", value: new object());
                    });

                    Assert.Equal("Value cannot be white space.\r\nParameter name: paramName",
                        exception.Message);
                }

                [Fact]
                public void NullValue_Throws()
                {
                    var exception = Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        Guard.Null("value", value: (object)null);
                    });

                    Assert.Equal("Value cannot be null.\r\nParameter name: value",
                        exception.Message);
                }

                [Fact]
                public void WithValue_ReturnsValue()
                {
                    var value = new object();

                    var result = Guard.Null(nameof(value), value);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}