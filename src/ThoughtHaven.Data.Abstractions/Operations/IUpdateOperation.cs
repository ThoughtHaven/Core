using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IUpdateOperation<TUpdate>
    {
        Task<TUpdate> Update(TUpdate update);
    }
}