using System.Threading.Tasks;

namespace ThoughtHaven.Data
{
    public interface IValidator<TValidate, TResult> where TResult : Task
    {
        TResult Validate(TValidate validate);
    }
}