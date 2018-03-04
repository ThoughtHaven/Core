using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface ICreateOperation<TCreate>
    {
        Task<TCreate> Create(TCreate create);
    }
}