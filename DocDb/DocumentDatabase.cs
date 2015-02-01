using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DocDb
{
    public class DocumentDatabase : IDocumentQueryable
    {
        private readonly IDocumentDatabaseProvider _provider;
        private readonly DocumentDatabaseMapper _mapper;

        public DocumentDatabase(IDocumentDatabaseProvider provider)
        {
            _provider = provider;
            _mapper = new DocumentDatabaseMapper();
        }

        public void Configure<T>(
            string documentType = null,
            Expression<Func<T, object>> id = null,
            Expression<Func<T, object>> key = null,
            Expression<Func<T, object>> index = null,
            Expression<Func<T, object>> timestamp = null)
        {
            _mapper.Configure(documentType, id, key, index, timestamp);
        }

        public async Task<T[]> GetAsync<T>(DocumentQuery query, CancellationToken cancellationToken)
        {
            using (IDocumentDatabaseProviderConnection connection = await _provider.OpenConnectionAsync(cancellationToken))
            {
                DocumentRow[] rows = await connection.QueryAsync(_mapper.GetDocumentType<T>(), query, cancellationToken);
                return rows.Select(r => _mapper.RowToDocument<T>(r)).ToArray();
            }
        }

        public async Task<DocumentMetadata[]> GetMetadataAsync<T>(DocumentQuery query, CancellationToken cancellationToken)
        {
            using (IDocumentDatabaseProviderConnection connection = await _provider.OpenConnectionAsync(cancellationToken))
            {
                return await connection.QueryMetadataAsync(_mapper.GetDocumentType<T>(), query, cancellationToken);
            }
        }

        public DocumentDatabaseTransaction BeginTransaction()
        {
            return new DocumentDatabaseTransaction(_provider, _mapper);
        }
    }
}