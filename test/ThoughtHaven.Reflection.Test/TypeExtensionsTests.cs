using System;
using System.Threading.Tasks;
using Xunit;

namespace ThoughtHaven.Reflection
{
    public class TypeExtensionsTests
    {
        public class HasDefaultConstructorMethod
        {
            public class TypeOverload
            {
                [Fact]
                public void Null_Throws()
                {
                    Assert.Throws<ArgumentNullException>("type", () =>
                    {
                        ((Type)null!).HasDefaultConstructor();
                    });
                }

                [Fact]
                public void WithDefaultConstructor_ReturnsTrue()
                {
                    var type = typeof(HasDefaultConstructor);

                    Assert.True(type.HasDefaultConstructor());
                }

                [Fact]
                public void WithoutDefaultConstructor_ReturnsFalse()
                {
                    var type = typeof(HasNoDefaultConstructor);

                    Assert.False(type.HasDefaultConstructor());
                }
            }
        }

        public class ImplementsMethod
        {
            public class TypeOverload
            {
                [Fact]
                public void Null_Throws()
                {
                    Type? nullType = null;

                    Assert.Throws<ArgumentNullException>("type", () =>
                    {
                        nullType!.Implements<IAsyncResult>();
                    });
                }

                [Fact]
                public void NotInterface_Throws()
                {
                    var exception = Assert.Throws<InvalidOperationException>(() =>
                    {
                        typeof(Uri).Implements<Uri>();
                    });

                    Assert.Equal("Only interfaces can be implemented.", exception.Message);
                }

                [Fact]
                public void IsImplemented_ReturnsTrue()
                {
                    var type = typeof(Task);

                    Assert.True(type.Implements<IAsyncResult>());
                }

                [Fact]
                public void IsNotImplemented_ReturnsFalse()
                {
                    var type = typeof(Uri);

                    Assert.False(type.Implements<IAsyncResult>());
                }
            }
        }

        private class HasDefaultConstructor { public HasDefaultConstructor() { } }

        private class HasNoDefaultConstructor
        { public HasNoDefaultConstructor(bool required) { } }
    }
}