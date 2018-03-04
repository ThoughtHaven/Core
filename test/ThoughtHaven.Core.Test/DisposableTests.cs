using System;
using ThoughtHaven.Fakes;
using Xunit;

namespace ThoughtHaven
{
    public class DisposableTests
    {
        public class Type
        {
            [Fact]
            public void ImplementsIDisposable()
            {
                Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Disposable)));
            }
        }

        public class DisposeMethod
        {
            public class EmptyOverload
            {
                [Fact]
                public void CallsOnDispose()
                {
                    var disposable = new FakeDisposable();

                    disposable.Dispose();

                    Assert.Equal(1, disposable.OnDispose_CallCount);
                }

                [Fact]
                public void CallsOnDisposeExactlyOnce()
                {
                    var disposable = new FakeDisposable();

                    disposable.Dispose();
                    disposable.Dispose();

                    Assert.Equal(1, disposable.OnDispose_CallCount);
                }
            }
        }
    }
}