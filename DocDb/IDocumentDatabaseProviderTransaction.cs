using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocDb
{
    public interface IDocumentDatabaseProviderTransaction : IDisposable, IDocumentDatabaseProviderQueryable
    {
        Task<DocumentMetadata> SaveAsync(DocumentRow row, CancellationToken cancellationToken);
        Task<int> DeleteAsync(string documentType, DocumentQuery query, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}