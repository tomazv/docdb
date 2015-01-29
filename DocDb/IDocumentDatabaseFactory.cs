using System;

namespace DocDb
{
    public interface IDocumentDatabaseFactory
    {
        IDocumentDatabase<T> Create<T>(string tableName);

        IDocumentDatabase<T> Create<T>(string tableName,
            Func<T, DocumentMetadata, T> createDocument,
            Func<T, DocumentMetadata, DocumentMetadata> createMetadata);

        IDocumentDatabase<TModel> Create<TDocument, TModel>(string tableName,
            Func<TModel, TDocument> createDocument,
            Func<TModel, DocumentMetadata, DocumentMetadata> createMetadata,
            Func<TDocument, DocumentMetadata, TModel> createModel);
    }
}
