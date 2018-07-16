﻿using System;
using Xunit;

namespace ThoughtHaven.Commerce
{
    public class USDTests
    {
        public class DisplayPriceProperty
        {
            [Fact]
            public void WhenCentsEquals199_Returns199()
            {
                var price = new USD(199);

                Assert.Equal("$1.99", price.DisplayPrice);
            }

            [Fact]
            public void WhenCentsEquals101_Returns101()
            {
                var price = new USD(101);

                Assert.Equal("$1.01", price.DisplayPrice);
            }

            [Fact]
            public void WhenCentsEquals100_Returns1()
            {
                var price = new USD(100);

                Assert.Equal("$1", price.DisplayPrice);
            }
        }

        public class Constructor
        {
            public class CentsOverload
            {
                [Fact]
                public void CentsEqualsZero_SetsCents()
                {
                    var usd = new USD(0);

                    Assert.Equal(0, usd.Cents);
                }

                [Fact]
                public void CentsEqualsOne_SetsCents()
                {
                    var usd = new USD(1);

                    Assert.Equal(1, usd.Cents);
                }

                [Fact]
                public void CentsBelow0_Throws()
                {
                    Assert.Throws<ArgumentOutOfRangeException>("cents", () =>
                    {
                        new USD(cents: -1);
                    });
                }
            }
        }

        public class ToStringMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void OneThousandCents_ReturnsFormatted()
                {
                    var usd = new USD(1000);

                    Assert.Equal("$10.00", usd.ToString());
                }

                [Fact]
                public void TenThousandCents_ReturnsFormatted()
                {
                    var usd = new USD(10000);

                    Assert.Equal("$100.00", usd.ToString());
                }

                [Fact]
                public void OneHundredCents_ReturnsFormatted()
                {
                    var usd = new USD(100);

                    Assert.Equal("$1.00", usd.ToString());
                }

                [Fact]
                public void TenCents_ReturnsFormatted()
                {
                    var usd = new USD(10);

                    Assert.Equal("$0.10", usd.ToString());
                }

                [Fact]
                public void OneCent_ReturnsFormatted()
                {
                    var usd = new USD(1);

                    Assert.Equal("$0.01", usd.ToString());
                }
            }
        }

        public class GetHashCodeMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void WhenCalled_ReturnsCentsGetHashCode()
                {
                    var usd = new USD(1);

                    Assert.Equal(usd.Cents.GetHashCode(), usd.GetHashCode());
                }
            }
        }

        public class EqualsMethod
        {
            public class ObjOverload
            {
                [Fact]
                public void NotUsdObj_ReturnsFalse()
                {
                    var usd = new USD(0);

                    Assert.False(usd.Equals("string"));
                }

                [Fact]
                public void NullObj_ReturnsFalse()
                {
                    var usd = new USD(0);

                    Assert.False(usd.Equals(obj: null));
                }

                [Fact]
                public void UsdObjWithSameCents_ReturnsTrue()
                {
                    var usd = new USD(0);

                    Assert.True(usd.Equals(new USD(0)));
                }

                [Fact]
                public void UsdObjWithDifferentCents_ReturnsFalse()
                {
                    var usd = new USD(0);

                    Assert.False(usd.Equals(new USD(1)));
                }

                [Fact]
                public void SameReferenceObj_ReturnsTrue()
                {
                    var usd = new USD(0);

                    Assert.True(usd.Equals(usd));
                }
            }
        }

        public class EqualsOperator
        {
            public class XAndYOverload
            {
                [Fact]
                public void SameReference_ReturnsTrue()
                {
                    USD usd = new USD(1);
                    USD x = usd;
                    USD y = usd;

                    Assert.True(x == y);
                }

                [Fact]
                public void NullX_ReturnsFalse()
                {
                    USD x = null;
                    USD y = new USD(1);

                    Assert.False(x == y);
                }

                [Fact]
                public void NullY_ReturnsFalse()
                {
                    USD x = new USD(1);
                    USD y = null;

                    Assert.False(x == y);
                }

                [Fact]
                public void NullXAndNullY_ReturnsTrue()
                {
                    USD x = null;
                    USD y = null;

                    Assert.True(x == y);
                }

                [Fact]
                public void DifferentCents_ReturnsFalse()
                {
                    USD x = new USD(1);
                    USD y = new USD(2);

                    Assert.False(x == y);
                }

                [Fact]
                public void SameCents_ReturnsTrue()
                {
                    USD x = new USD(1);
                    USD y = new USD(1);

                    Assert.True(x == y);
                }
            }
        }

        public class NotEqualsOperator
        {
            public class XAndYOverload
            {
                [Fact]
                public void SameReference_ReturnsFalse()
                {
                    USD usd = new USD(1);
                    USD x = usd;
                    USD y = usd;

                    Assert.False(x != y);
                }

                [Fact]
                public void NullX_ReturnsTrue()
                {
                    USD x = null;
                    USD y = new USD(1);

                    Assert.True(x != y);
                }

                [Fact]
                public void NullY_ReturnsTrue()
                {
                    USD x = new USD(1);
                    USD y = null;

                    Assert.True(x != y);
                }

                [Fact]
                public void NullXAndNullY_ReturnsFalse()
                {
                    USD x = null;
                    USD y = null;

                    Assert.False(x != y);
                }

                [Fact]
                public void DifferentCents_ReturnsTrue()
                {
                    USD x = new USD(1);
                    USD y = new USD(2);

                    Assert.True(x != y);
                }

                [Fact]
                public void SameCents_ReturnsFalse()
                {
                    USD x = new USD(1);
                    USD y = new USD(1);

                    Assert.False(x != y);
                }
            }
        }
    }
}