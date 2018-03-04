using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IMergeOperation<TMerge>
    {
        Task<TMerge> Merge(TMerge merge);
    }
}