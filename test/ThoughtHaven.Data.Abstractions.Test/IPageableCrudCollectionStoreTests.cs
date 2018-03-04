using Xunit;

namespace ThoughtHaven.Data
{
    public class IPageableCrudCollectionStoreTests
    {
        public class Type
        {
            [Fact]
            public void InheritsICrudCollectionStore()
            {
                Assert.True(typeof(ICrudCollectionStore<string, object>)
                    .IsAssignableFrom(typeof(IPageableCrudCollectionStore<string, object>)));
            }

            [Fact]
            public void InheritsIRetrievePageableCollectionOperation()
            {
                Assert.True(typeof(IRetrievePageableCollectionOperation<object>)
                    .IsAssignableFrom(typeof(IPageableCrudCollectionStore<string, object>)));
            }
        }
    }
}