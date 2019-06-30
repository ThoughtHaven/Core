namespace ThoughtHaven.Data
{
    public interface ICrudStore<TKey, TData>
        : IRetrieveOperation<TKey, TData>,
        ICreateOperation<TData>,
        IUpdateOperation<TData>,
        IDeleteOperation<TKey>
        where TData : class
    { }
}