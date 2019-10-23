using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class StringGuardTests
    {
        public class NullOrEmptyMethod
        {
            public class ParamNameAndValueOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.NullOrEmpty(paramName: null!, value: "valid");
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NullOrEmpty(paramName: "", value: "valid");
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NullOrEmpty(paramName: " ", value: "valid");
                    });
                }

                [Fact]
                public void NullValue_Throws()
                {
                    string? @null = null;

                    Assert.Throws<ArgumentNullException>(nameof(@null), () =>
                    {
                        Guard.NullOrEmpty(nameof(@null), @null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    string empty = string.Empty;

                    var exception = Assert.Throws<ArgumentException>(nameof(empty), () =>
                    {
                        Guard.NullOrEmpty(nameof(empty), empty);
                    });

                    Assert.Equal("Value cannot be empty. (Parameter 'empty')",
                        exception.Message);
                }

                [Fact]
                public void ValidValue_ReturnsValue()
                {
                    var valid = "valid";

                    var result = Guard.NullOrEmpty(nameof(valid), valid);

                    Assert.Equal("valid", result);
                }

                [Fact]
                public void WhiteSpaceValue_ReturnValue()
                {
                    string whitespace = " ";

                    var result = Guard.NullOrEmpty(nameof(whitespace), whitespace);

                    Assert.Equal(" ", result);
                }
            }
        }

        public class NullOrWhiteSpaceMethod
        {
            public class ParamNameAndValueOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.NullOrWhiteSpace(paramName: null!, value: "valid");
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NullOrWhiteSpace(paramName: "", value: "valid");
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NullOrWhiteSpace(paramName: " ", value: "valid");
                    });
                }

                [Fact]
                public void NullValue_Throws()
                {
                    string? @null = null;

                    Assert.Throws<ArgumentNullException>(nameof(@null), () =>
                    {
                        Guard.NullOrWhiteSpace(nameof(@null), @null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    string empty = string.Empty;

                    Assert.Throws<ArgumentException>(nameof(empty), () =>
                    {
                        Guard.NullOrWhiteSpace(nameof(empty), empty);
                    });
                }

                [Fact]
                public void WhiteSpaceValue_Throws()
                {
                    string whitespace = " ";

                    var exception = Assert.Throws<ArgumentException>(nameof(whitespace), () =>
                    {
                        Guard.NullOrWhiteSpace(nameof(whitespace), whitespace);
                    });

                    Assert.Equal("Value cannot be white space. (Parameter 'whitespace')",
                        exception.Message);
                }

                [Fact]
                public void ValidValue_ReturnsValue()
                {
                    var valid = "valid";

                    var result = Guard.NullOrWhiteSpace(nameof(valid), valid);

                    Assert.Equal(valid, result);
                }
            }
        }
    }
}