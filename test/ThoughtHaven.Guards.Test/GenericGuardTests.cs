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
                        Guard.Null(paramName: null!, value: new object());
                    });

                    Assert.Equal("Value cannot be null. (Parameter 'paramName')",
                        exception.Message);
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    var exception = Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.Null(paramName: "", value: new object());
                    });

                    Assert.Equal("Value cannot be empty. (Parameter 'paramName')",
                        exception.Message);
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    var exception = Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.Null(paramName: " ", value: new object());
                    });

                    Assert.Equal("Value cannot be white space. (Parameter 'paramName')",
                        exception.Message);
                }

                [Fact]
                public void NullValue_Throws()
                {
                    var exception = Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        Guard.Null<object>("value", value: null!);
                    });

                    Assert.Equal("Value cannot be null. (Parameter 'value')",
                        exception.Message);
                }

                [Fact]
                public void WithReferenceTypeValue_ReturnsValue()
                {
                    var value = new object();

                    var result = Guard.Null(nameof(value), value);

                    Assert.Equal(value, result);
                }

                [Fact]
                public void WithValueTypeValue_ReturnsValue()
                {
                    var value = 5;

                    var result = Guard.Null(nameof(value), value);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}