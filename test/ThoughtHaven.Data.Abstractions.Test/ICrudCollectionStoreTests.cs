using Xunit;

namespace ThoughtHaven.Data
{
    public class ICrudCollectionStoreTests
    {
        public class Type
        {
            [Fact]
            public void InheritsICrudStore()
            {
                Assert.True(typeof(ICrudStore<string, object>)
                    .IsAssignableFrom(typeof(ICrudCollectionStore<string, object>)));
            }

            [Fact]
            public void InheritsIRetrieveCollectionOperation()
            {
                Assert.True(typeof(IRetrieveCollectionOperation<object>)
                    .IsAssignableFrom(typeof(ICrudCollectionStore<string, object>)));
            }
        }
    }
}
