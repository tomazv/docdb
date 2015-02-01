using System.Threading;
using System.Threading.Tasks;

namespace DocDb
{
    public interface IDocumentDatabaseProvider
    {
        Task<IDocumentDatabaseProviderConnection> OpenConnectionAsync(CancellationToken cancellationToken);
        Task<IDocumentDatabaseProviderTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}