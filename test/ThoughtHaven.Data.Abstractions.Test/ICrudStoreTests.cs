using Xunit;

namespace ThoughtHaven.Data
{
    public class ICrudStoreTests
    {
        public class Type
        {
            [Fact]
            public void InheritsIRetrieveOperation()
            {
                Assert.True(typeof(IRetrieveOperation<string, object>)
                    .IsAssignableFrom(typeof(ICrudStore<string, object>)));
            }

            [Fact]
            public void InheritsICreateOperation()
            {
                Assert.True(typeof(ICreateOperation<object>)
                    .IsAssignableFrom(typeof(ICrudStore<string, object>)));
            }

            [Fact]
            public void InheritsIUpdateOperation()
            {
                Assert.True(typeof(IUpdateOperation<object>)
                    .IsAssignableFrom(typeof(ICrudStore<string, object>)));
            }

            [Fact]
            public void InheritsIDeleteOperation()
            {
                Assert.True(typeof(IDeleteOperation<string>)
                    .IsAssignableFrom(typeof(ICrudStore<string, object>)));
            }
        }
    }
}