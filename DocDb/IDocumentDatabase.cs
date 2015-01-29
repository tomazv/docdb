namespace DocDb
{
    public interface IDocumentDatabase<T> : IDocumentQueryable<T>
    {
        IDocumentDatabaseTransaction<T> BeginTransaction();
    }
}