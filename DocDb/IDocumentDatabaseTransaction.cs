using System;

namespace DocDb
{
    public interface IDocumentDatabaseTransaction<T> : IDisposable, IDocumentQueryable<T>
    {
        T Save(T document, bool checkConcurrency = false);
        int Delete(int documentId, long? updatedTimestamp = null);
        void Commit();
        void Rollback();
    }
}