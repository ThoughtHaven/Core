using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IRetrieveOperation<TKey, TRetrieve>
    {
        Task<TRetrieve> Retrieve(TKey key);
    }
}