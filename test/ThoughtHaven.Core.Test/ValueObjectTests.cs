using System;
using Xunit;

namespace ThoughtHaven
{
    public class ValueObjectTests
    {
        public class Type
        {
            [Fact]
            public void ImplementsIEquatableOfValueObject()
            {
                Assert.True(typeof(IEquatable<ValueObject<object>>)
                    .IsAssignableFrom(typeof(ValueObject<object>)));
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
                            new ValueObject<object>(value: null);
                        });
                }

                [Fact]
                public void ValidValue_SetsValue()
                {
                    var value = new object();

                    var valueObject = new ValueObject<object>(value);

                    Assert.Equal(value, valueObject.Value);
                }
            }
        }

        public class GetHashCodeMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void WhenCalled_MatchesValueHashCode()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);

                    var result = valueObject.GetHashCode();

                    Assert.Equal(value.GetHashCode(), result);
                    Assert.Equal(valueObject.Value.GetHashCode(), result);
                }
            }
        }

        public class EqualsMethod
        {
            public class ObjectOverload
            {
                [Fact]
                public void SelfAsObject_ReturnsTrue()
                {
                    var valueObject = new ValueObject<string>("value");
                    object compareObject = valueObject;

                    Assert.True(valueObject.Equals(compareObject));
                }

                [Fact]
                public void SameValue_ReturnsTrue()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    object compareObject = new ValueObject<object>(value);

                    Assert.True(valueObject.Equals(compareObject));
                }

                [Fact]
                public void NullObject_ReturnsFalse()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    object compareObject = null;

                    Assert.False(valueObject.Equals(compareObject));
                }

                [Fact]
                public void DifferentType_ReturnsFalse()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    object compareObject = "Something Else";

                    Assert.False(valueObject.Equals(compareObject));
                }

                [Fact]
                public void DifferentValue_ReturnsFalse()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    object compareObject = new ValueObject<object>("Something Else");

                    Assert.False(valueObject.Equals(compareObject));
                }
            }

            public class OtherOverload
            {
                [Fact]
                public void SelfAsOther_ReturnsTrue()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    ValueObject<object> compareObject = valueObject;

                    Assert.True(valueObject.Equals(compareObject));
                }

                [Fact]
                public void SameValue_ReturnsTrue()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    var compareObject = new ValueObject<object>(value);

                    Assert.True(valueObject.Equals(compareObject));
                }

                [Fact]
                public void Null_ReturnsFalse()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    ValueObject<object> compareObject = null;

                    Assert.False(valueObject.Equals(compareObject));
                }

                [Fact]
                public void DifferentValue_ReturnsFalse()
                {
                    var value = new object();
                    var valueObject = new ValueObject<object>(value);
                    var compareObject = new ValueObject<object>("Something Else");

                    Assert.False(valueObject.Equals(compareObject));
                }
            }
        }

        public class EqualsOperator
        {
            [Fact]
            public void SelfAsValueObject_ReturnsTrue()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                ValueObject<object> compareObject = valueObject;

                Assert.True(valueObject == compareObject);
            }

            [Fact]
            public void SameValue_ReturnsTrue()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                var compareObject = new ValueObject<object>(value);

                Assert.True(valueObject == compareObject);
            }

            [Fact]
            public void Null_ReturnsFalse()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                ValueObject<object> compareObject = null;

                Assert.False(valueObject == compareObject);
            }

            [Fact]
            public void DifferentValue_ReturnsFalse()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                var compareObject = new ValueObject<object>("Something Else");

                Assert.False(valueObject == compareObject);
            }
        }

        public class NotEqualsOperator
        {
            [Fact]
            public void SelfAsValueObject_ReturnsFalse()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                ValueObject<object> compareObject = valueObject;

                Assert.False(valueObject != compareObject);
            }

            [Fact]
            public void SameValue_ReturnsFalse()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                var compareObject = new ValueObject<object>(value);

                Assert.False(valueObject != compareObject);
            }

            [Fact]
            public void Null_ReturnsTrue()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                ValueObject<object> compareObject = null;

                Assert.True(valueObject != compareObject);
            }

            [Fact]
            public void DifferentValue_ReturnsTrue()
            {
                var value = new object();
                var valueObject = new ValueObject<object>(value);
                var compareObject = new ValueObject<object>("Something Else");

                Assert.True(valueObject != compareObject);
            }
        }
    }
}