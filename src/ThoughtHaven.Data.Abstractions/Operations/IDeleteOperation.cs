using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IDeleteOperation<TKey>
    {
        Task Delete(TKey key);
    }
}