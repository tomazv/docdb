using System.Threading;
using System.Threading.Tasks;

namespace DocDb
{
    public interface IDocumentDatabaseProviderQueryable
    {
        Task<DocumentRow[]> QueryAsync(string documentType, DocumentQuery query, CancellationToken cancellationToken);

        Task<DocumentMetadata[]> QueryMetadataAsync(string documentType, DocumentQuery query,
            CancellationToken cancellationToken);
    }
}