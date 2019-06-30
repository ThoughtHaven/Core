using System;
using System.Threading.Tasks;
using Xunit;

namespace ThoughtHaven.Reflection
{
    public class ReflectedObjectExtensionsTests
    {
        public class ImplementsMethod
        {
            public class TypeOverload
            {
                [Fact]
                public void NullObject_Throws()
                {
                    Uri? nullUri = null;

                    Assert.Throws<ArgumentNullException>("object", () =>
                    {
                        nullUri!.Implements<IAsyncResult>();
                    });
                }

                [Fact]
                public void NotInterface_Throws()
                {
                    var uri = new Uri("http://www.example.com");

                    Assert.Throws<InvalidOperationException>(() =>
                    {
                        uri.Implements<Uri>();
                    });
                }

                [Fact]
                public void Implemented_ReturnsTrue()
                {
                    var task = Task.CompletedTask;

                    Assert.True(task.Implements<IAsyncResult>());
                }

                [Fact]
                public void NotImplemented_ReturnsFalse()
                {
                    var uri = new Uri("http://www.example.com");

                    Assert.False(uri.Implements<IAsyncResult>());
                }
            }
        }
    }
}