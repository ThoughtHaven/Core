using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IRetrievePageableCollectionOperation<TRetrieve>
    {
        Task<IEnumerable<TRetrieve>> Retrieve(int skip, int take);
    }
}