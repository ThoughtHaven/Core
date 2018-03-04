using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IRetrieveCollectionOperation<TRetrieve>
    {
        Task<IEnumerable<TRetrieve>> Retrieve();
    }
}