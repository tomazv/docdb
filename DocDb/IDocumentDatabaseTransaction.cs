using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DocDb
{
    public class DocumentDatabaseTransaction : IDisposable, IDocumentQueryable
    {
        private readonly DocumentDatabaseMapper _mapper;
        private readonly IDocumentDatabaseProviderTransaction _transaction;

        private DocumentDatabaseTransaction(IDocumentDatabaseProviderTransaction transaction, DocumentDatabaseMapper mapper)
        {
            _mapper = mapper;
            _transaction = transaction;
        }

        public static async Task<DocumentDatabaseTransaction> BeginAsync(IDocumentDatabaseProvider provider,
            DocumentDatabaseMapper mapper, CancellationToken cancellationToken)
        {
            IDocumentDatabaseProviderTransaction transaction = await provider.BeginTransactionAsync(cancellationToken);
            return new DocumentDatabaseTransaction(transaction, mapper);
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public async Task<T[]> GetAsync<T>(DocumentQuery query, CancellationToken cancellationToken)
        {
            DocumentRow[] rows = await _transaction.QueryAsync(_mapper.GetDocumentType<T>(), query, cancellationToken);
            return rows.Select(r => _mapper.RowToDocument<T>(r)).ToArray();
        }

        public Task<DocumentMetadata[]> GetMetadataAsync<T>(DocumentQuery query, CancellationToken cancellationToken)
        {
            return _transaction.QueryMetadataAsync(_mapper.GetDocumentType<T>(), query, cancellationToken);
        }

        public async Task SaveAsync<T>(T document, CancellationToken cancellationToken)
        {
            DocumentMetadata metadata = await _transaction.SaveAsync(_mapper.DocumentToRow(document), cancellationToken);
            _mapper.FillDocument(document, metadata);
        }

        public Task<int> DeleteAsync<T>(int documentId, int timestamp, CancellationToken cancellationToken)
        {
            return _transaction.DeleteAsycn(_mapper.GetDocumentType<T>(), documentId, timestamp, cancellationToken);
        }

        public Task<int> DeleteAsync<T>(int documentId, CancellationToken cancellationToken)
        {
            return _transaction.DeleteAsycn(_mapper.GetDocumentType<T>(), documentId, cancellationToken);
        }

        public Task<int> DeleteAllAsync<T>(CancellationToken cancellationToken)
        {
            return _transaction.DeleteAllAsync(_mapper.GetDocumentType<T>(), cancellationToken);
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _transaction.CommitAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken)
        {
            return _transaction.RollbackAsync(cancellationToken);
        }
    }
}