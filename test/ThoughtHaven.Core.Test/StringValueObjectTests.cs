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

            public class ValueAndValidCharactersOverload
            {
                [Fact]
                public void NullValidCharacters_Throws()
                {
                    Assert.Throws<ArgumentNullException>("validCharacters", () =>
                    {
                        new StringValueObject("value", validCharacters: null);
                    });
                }

                [Fact]
                public void EmptyValidCharacters_Throws()
                {
                    Assert.Throws<ArgumentException>("validCharacters", () =>
                    {
                        new StringValueObject("value", validCharacters: "");
                    });
                }

                [Fact]
                public void WhiteSpaceValidCharacters_Throws()
                {
                    Assert.Throws<ArgumentException>("validCharacters", () =>
                    {
                        new StringValueObject("value", validCharacters: " ");
                    });
                }

                [Fact]
                public void ValueWithInvalidCharacters_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        new StringValueObject("a", validCharacters: "b");
                    });
                }

                [Fact]
                public void WhenCalled_SetsValue()
                {
                    var value = new StringValueObject("a", validCharacters: "a");

                    Assert.Equal("a", value.Value);
                }
            }
        }
    }
}