using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface ICreateOrUpdateOperation<TCreateOrUpdate>
    {
        Task<TCreateOrUpdate> CreateOrUpdate(TCreateOrUpdate createOrUpdate);
    }
}