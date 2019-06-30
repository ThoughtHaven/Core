using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IRetrieveOperation<TKey, TRetrieve>
        where TRetrieve : class
    {
        Task<TRetrieve?> Retrieve(TKey key);
    }
}