namespace ThoughtHaven.Data
{
    public interface ICrudCollectionStore<TKey, TData>
        : ICrudStore<TKey, TData>, IRetrieveCollectionOperation<TData>
    { }
}