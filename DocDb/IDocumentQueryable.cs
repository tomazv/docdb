using System.Threading;
using System.Threading.Tasks;

namespace DocDb
{
    public interface IDocumentQueryable
    {
        Task<T[]> GetAsync<T>(DocumentQuery query, CancellationToken cancellationToken);
        Task<DocumentMetadata[]> GetMetadataAsync<T>(DocumentQuery query, CancellationToken cancellationToken);
    }
}