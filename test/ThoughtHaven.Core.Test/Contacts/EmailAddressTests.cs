using System;
using Xunit;

namespace ThoughtHaven.Contacts
{
    public class EmailAddressTests
    {
        public class Constructor
        {
            public class ValueOverload
            {
                [Fact]
                public void NullValue_Throws()
                {
                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        new EmailAddress(value: null);
                    });
                }

                [Fact]
                public void ValueWithoutAtSymbol_Throws()
                {
                    var value = "invalid";

                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        new EmailAddress(value);
                    });
                }

                [Fact]
                public void ValueWithSpaces_TrimsValue()
                {
                    var value = " some@email.com ";

                    var email = new EmailAddress(value);

                    Assert.Equal("some@email.com", email.Value);
                }

                [Fact]
                public void UppercaseValue_LowersValue()
                {
                    var value = "SOME@EMAIL.COM";

                    var email = new EmailAddress(value);

                    Assert.Equal("some@email.com", email.Value);
                }
            }
        }

        public class ToStringMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void ReturnsValue()
                {
                    var email = new EmailAddress("some@email.com");

                    Assert.Equal("some@email.com", email.ToString());
                }
            }
        }

        public class EmailAddressOperator
        {
            public class ValueOverload
            {
                [Fact]
                public void NullValue_Throws()
                {
                    string value = null;

                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        EmailAddress email = value;
                    });
                }

                [Fact]
                public void ValueWithoutAtSymbol_Throws()
                {
                    var value = "invalid";

                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        EmailAddress email = value;
                    });
                }

                [Fact]
                public void ValueWithSpaces_TrimsValue()
                {
                    var value = " some@email.com ";

                    EmailAddress email = value;

                    Assert.Equal("some@email.com", email.Value);
                }

                [Fact]
                public void UppercaseValue_LowersValue()
                {
                    var value = "SOME@EMAIL.COM";

                    EmailAddress email = value;

                    Assert.Equal("some@email.com", email.Value);
                }
            }
        }
    }
}