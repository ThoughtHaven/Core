using System;
using Xunit;

namespace ThoughtHaven.Contacts
{
    public class LandAddressTests
    {
        public class ParseMethod
        {
            public class AddressOverload
            {
                [Fact]
                public void NullAddress_Throws()
                {
                    Assert.Throws<ArgumentNullException>("address", () =>
                    {
                        LandAddress.Parse(address: null!);
                    });
                }

                [Fact]
                public void EmptyAddress_Throws()
                {
                    Assert.Throws<ArgumentException>("address", () =>
                    {
                        LandAddress.Parse(address: "");
                    });
                }

                [Fact]
                public void WhiteSpaceAddress_Throws()
                {
                    Assert.Throws<ArgumentException>("address", () =>
                    {
                        LandAddress.Parse(address: " ");
                    });
                }

                [Fact]
                public void InvalidFormat_Throws()
                {
                    var exception = Assert.Throws<FormatException>(() =>
                    {
                        LandAddress.Parse("Invalid format and such");
                    });

                    Assert.Equal("Invalid LandAddress format. Correct format is '123 Fake Street, New York City, New York 10001, United States'.",
                        exception.Message);
                }

                [Fact]
                public void WhenCalled_ReturnsLandAddress()
                {
                    var address = LandAddress.Parse("123 Fake Street, New York City, New York 10001, United States");

                    Assert.Equal("123 Fake Street", address.StreetAddress);
                    Assert.Equal("New York City", address.City);
                    Assert.Equal("New York", address.State);
                    Assert.Equal("10001", address.PostalCode);
                    Assert.Equal("United States", address.Country);
                }
            }
        }

        public class Constructor
        {
            public class PrimaryOverload
            {
                [Fact]
                public void NullStreetAddress_Throws()
                {
                    Assert.Throws<ArgumentNullException>("streetAddress", () =>
                    {
                        new LandAddress(
                            streetAddress: null!,
                            city: "City",
                            state: "State",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void EmptyStreetAddress_Throws()
                {
                    Assert.Throws<ArgumentException>("streetAddress", () =>
                    {
                        new LandAddress(
                            streetAddress: "",
                            city: "City",
                            state: "State",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void WhiteSpaceStreetAddress_Throws()
                {
                    Assert.Throws<ArgumentException>("streetAddress", () =>
                    {
                        new LandAddress(
                            streetAddress: " ",
                            city: "City",
                            state: "State",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void NullCity_Throws()
                {
                    Assert.Throws<ArgumentNullException>("city", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: null!,
                            state: "State",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void EmptyCity_Throws()
                {
                    Assert.Throws<ArgumentException>("city", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "",
                            state: "State",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void WhiteSpaceCity_Throws()
                {
                    Assert.Throws<ArgumentException>("city", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: " ",
                            state: "State",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void NullState_Throws()
                {
                    Assert.Throws<ArgumentNullException>("state", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: null!,
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void EmptyState_Throws()
                {
                    Assert.Throws<ArgumentException>("state", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void WhiteSpaceState_Throws()
                {
                    Assert.Throws<ArgumentException>("state", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: " ",
                            country: "USA",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void NullCountry_Throws()
                {
                    Assert.Throws<ArgumentNullException>("country", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "State",
                            country: null!,
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void EmptyCountry_Throws()
                {
                    Assert.Throws<ArgumentException>("country", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "State",
                            country: "",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void WhiteSpaceCountry_Throws()
                {
                    Assert.Throws<ArgumentException>("country", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "State",
                            country: " ",
                            postalCode: "12345");
                    });
                }

                [Fact]
                public void NullPostalCode_Throws()
                {
                    Assert.Throws<ArgumentNullException>("postalCode", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "State",
                            country: "USA",
                            postalCode: null!);
                    });
                }

                [Fact]
                public void EmptyPostalCode_Throws()
                {
                    Assert.Throws<ArgumentException>("postalCode", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "State",
                            country: "USA",
                            postalCode: "");
                    });
                }

                [Fact]
                public void WhiteSpacePostalCode_Throws()
                {
                    Assert.Throws<ArgumentException>("postalCode", () =>
                    {
                        new LandAddress(
                            streetAddress: "123 Fake Street",
                            city: "City",
                            state: "State",
                            country: "USA",
                            postalCode: " ");
                    });
                }

                [Fact]
                public void WhenCalled_SetsStreetAddress()
                {
                    var streetAddress = "123 Fake Street";
                    var city = "City";
                    var state = "State";
                    var postalCode = "12345";
                    var country = "USA";

                    var address = new LandAddress(streetAddress, city, state, postalCode,
                        country);

                    Assert.Equal(streetAddress, address.StreetAddress);
                }

                [Fact]
                public void WhenCalled_SetsCity()
                {
                    var streetAddress = "123 Fake Street";
                    var city = "City";
                    var state = "State";
                    var postalCode = "12345";
                    var country = "USA";

                    var address = new LandAddress(streetAddress, city, state, postalCode,
                        country);

                    Assert.Equal(city, address.City);
                }

                [Fact]
                public void WhenCalled_SetsState()
                {
                    var streetAddress = "123 Fake Street";
                    var city = "City";
                    var state = "State";
                    var postalCode = "12345";
                    var country = "USA";

                    var address = new LandAddress(streetAddress, city, state, postalCode,
                        country);

                    Assert.Equal(state, address.State);
                }

                [Fact]
                public void WhenCalled_SetsPostalCode()
                {
                    var streetAddress = "123 Fake Street";
                    var city = "City";
                    var state = "State";
                    var postalCode = "12345";
                    var country = "USA";

                    var address = new LandAddress(streetAddress, city, state, postalCode,
                        country);

                    Assert.Equal(postalCode, address.PostalCode);
                }

                [Fact]
                public void WhenCalled_SetsCountry()
                {
                    var streetAddress = "123 Fake Street";
                    var city = "City";
                    var state = "State";
                    var postalCode = "12345";
                    var country = "USA";

                    var address = new LandAddress(streetAddress, city, state, postalCode,
                        country);

                    Assert.Equal(country, address.Country);
                }
            }
        }

        public class ToStringMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void WhenCalled_ReturnsValue()
                {
                    var streetAddress = "123 Fake Street";
                    var city = "City";
                    var state = "State";
                    var postalCode = "12345";
                    var country = "USA";

                    var address = new LandAddress(streetAddress, city, state, postalCode,
                        country);

                    Assert.Equal("123 Fake Street, City, State 12345, USA",
                        address.ToString());
                }
            }
        }
    }
}