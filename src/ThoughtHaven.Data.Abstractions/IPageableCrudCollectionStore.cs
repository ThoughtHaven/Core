namespace ThoughtHaven.Data
{
    public interface IPageableCrudCollectionStore<TKey, TData>
        : ICrudCollectionStore<TKey, TData>, IRetrievePageableCollectionOperation<TData>
    { }
}