using System;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class GuidGuardTests
    {
        public class EmptyMethod
        {
            public class ParamNameAndValueOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.Empty(paramName: null, value: Guid.NewGuid());
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.Empty(paramName: "", value: Guid.NewGuid());
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.Empty(paramName: " ", value: Guid.NewGuid());
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    var empty = Guid.Empty;
                    var paramName = nameof(empty);

                    var exception = Assert.Throws<ArgumentException>(paramName, () =>
                    {
                        Guard.Empty(paramName: paramName, value: empty);
                    });

                    Assert.Equal("Value cannot be an empty Guid.\r\nParameter name: empty",
                        exception.Message);
                }

                [Fact]
                public void DefaultValue_Throws()
                {
                    var @default = default(Guid);
                    var paramName = nameof(@default);

                    Assert.Throws<ArgumentException>(paramName, () =>
                    {
                        Guard.Empty(paramName: paramName, value: @default);
                    });
                }

                [Fact]
                public void ValidValue_ReturnsValue()
                {
                    var valid = Guid.NewGuid();

                    var result = Guard.Empty(nameof(valid), valid);

                    Assert.Equal(valid, result);
                }
            }
        }
    }
}