using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace DocDb
{
    public class DocumentDatabaseMapper
    {
        private readonly ConcurrentDictionary<Type, object> _configurations = new ConcurrentDictionary<Type, object>(); 

        public void Configure<T>(
            string documentType = null,
            Expression<Func<T, object>> id = null,
            Expression<Func<T, object>> key = null,
            Expression<Func<T, object>> index = null,
            Expression<Func<T, object>> timestamp = null)
        {
            if (!_configurations.TryAdd(typeof(T), new DocumentConfiguration<T>(documentType, id, key, index, timestamp)))
                throw new InvalidOperationException(string.Format("Type '{0}', already configured.", typeof(T)));
        }

        public string GetDocumentType<T>()
        {
            DocumentConfiguration<T> configuration = GetConfiguration<T>();
            return configuration == null || configuration.DocumentType == null
                ? typeof (T).Name
                : configuration.DocumentType;
        }

        private DocumentConfiguration<T> GetConfiguration<T>()
        {
            object value;
            return _configurations.TryGetValue(typeof (T), out value)
                ? (DocumentConfiguration<T>) value
                : null;
        }

        public T RowToDocument<T>(DocumentRow documentRow)
        {
            T document = JsonConvert.DeserializeObject<T>(documentRow.Content);
            FillDocument(document, documentRow.Metadata);
            return document;
        }

        public DocumentRow DocumentToRow<T>(T document)
        {
            string content = JsonConvert.SerializeObject(document);
            DocumentMetadata metadata = CreateMetaData(document);
            return new DocumentRow(content, metadata);
        }

        private DocumentMetadata CreateMetaData<T>(T document)
        {
            DocumentConfiguration<T> configuration = GetConfiguration<T>();
            return new DocumentMetadata(
                configuration == null ? 0 : (int)Reflect<T>.GetProperty(configuration.Id).GetValue(document),
                configuration == null ? null : (string)Reflect<T>.GetProperty(configuration.Key).GetValue(document),
                configuration == null ? null : (string)Reflect<T>.GetProperty(configuration.Index).GetValue(document),
                configuration == null ? 0 : (int)Reflect<T>.GetProperty(configuration.Timestamp).GetValue(document));
        }

        public void FillDocument<T>(T document, DocumentMetadata metadata)
        {
            DocumentConfiguration<T> configuration = GetConfiguration<T>();
            if (configuration != null)
            {
                if (configuration.Id != null)
                    Reflect<T>.GetProperty(configuration.Id).SetValue(document, metadata.Id);
                if (configuration.Key != null)
                    Reflect<T>.GetProperty(configuration.Key).SetValue(document, metadata.Key);
                if (configuration.Index != null)
                    Reflect<T>.GetProperty(configuration.Index).SetValue(document, metadata.Index);
                if (configuration.Timestamp != null)
                    Reflect<T>.GetProperty(configuration.Timestamp).SetValue(document, metadata.Timestamp);
            }
        }
    }
}