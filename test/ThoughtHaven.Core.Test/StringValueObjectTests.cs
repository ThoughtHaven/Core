using System;
using Xunit;

namespace ThoughtHaven
{
    public class StringValueObjectTests
    {
        public class Type
        {
            [Fact]
            public void ImplementsValueObjectOfString()
            {
                Assert.True(typeof(ValueObject<string>).IsAssignableFrom(
                    typeof(StringValueObject)));
            }
        }

        public class Constructor
        {
            public class ValueOverload
            {
                [Fact]
                public void NullValue_Throws()
                {
                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        new StringValueObject(value: null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        new StringValueObject(value: "");
                    });
                }

                [Fact]
                public void WhiteSpaceValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        new StringValueObject(value: " ");
                    });
                }

                [Fact]
                public void ValidValue_SetsValue()
                {
                    var valid = new StringValueObject("valid");

                    Assert.Equal("valid", valid.Value);
                }
            }
        }
    }
}