using System;
using System.Collections.Generic;
using Xunit;

namespace ThoughtHaven.Guards
{
    public class EnumerableGuardTests
    {
        public class NoItemsMethod
        {
            public class ParamNameAndValueOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.NoItems(paramName: null, value: "valid");
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NoItems(paramName: "", value: "valid");
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NoItems(paramName: " ", value: "valid");
                    });
                }

                [Fact]
                public void NullValue_Throws()
                {
                    IEnumerable<string> @null = null;

                    Assert.Throws<ArgumentNullException>(nameof(@null), () =>
                    {
                        Guard.NoItems(nameof(@null), @null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    IEnumerable<string> empty = new string[0];

                    var exception = Assert.Throws<ArgumentException>(nameof(empty), () =>
                    {
                        Guard.NoItems(nameof(empty), empty);
                    });

                    Assert.Equal("Value cannot contain no items.\r\nParameter name: empty",
                        exception.Message);
                }

                [Fact]
                public void ValidValue_ReturnsValue()
                {
                    IEnumerable<string> value = new string[] { "item" };

                    var result = Guard.NoItems(nameof(value), value);

                    Assert.Equal(value, result);
                }
            }
        }
        
        public class NullItemMethod
        {
            public class ParamNameAndValueOverload
            {
                [Fact]
                public void NullParamName_Throws()
                {
                    Assert.Throws<ArgumentNullException>("paramName", () =>
                    {
                        Guard.NullItem(paramName: null, value: "valid");
                    });
                }

                [Fact]
                public void EmptyParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NullItem(paramName: "", value: "valid");
                    });
                }

                [Fact]
                public void WhiteSpaceParamName_Throws()
                {
                    Assert.Throws<ArgumentException>("paramName", () =>
                    {
                        Guard.NullItem(paramName: " ", value: "valid");
                    });
                }

                [Fact]
                public void NullValue_Throws()
                {
                    IEnumerable<string> @null = null;

                    Assert.Throws<ArgumentNullException>(nameof(@null), () =>
                    {
                        Guard.NullItem(nameof(@null), @null);
                    });
                }

                [Fact]
                public void ValueHasNullItem_Throws()
                {
                    IEnumerable<string> hasNullItem = new string[] { "item1", null, "item2" };

                    var exception = Assert.Throws<ArgumentException>(nameof(hasNullItem), () =>
                    {
                        Guard.NullItem(nameof(hasNullItem), hasNullItem);
                    });

                    Assert.Equal("Collection contains a null item at the index: 1.\r\nParameter name: hasNullItem",
                        exception.Message);
                }

                [Fact]
                public void ValidItems_ReturnsValue()
                {
                    IEnumerable<string> value = new string[] { "item1", "item2" };

                    var result = Guard.NullItem(nameof(value), value);

                    Assert.Equal(value, result);
                }
            }
        }
    }
}