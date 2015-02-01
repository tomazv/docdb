using System;

namespace DocDb
{
    public interface IDocumentDatabaseProviderConnection : IDisposable, IDocumentDatabaseProviderQueryable
    {
    }
}