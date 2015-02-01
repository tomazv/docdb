using System;
using System.Linq.Expressions;

namespace DocDb
{
    public class DocumentConfiguration<T>
    {
        public string DocumentType { get; private set; }
        public Expression<Func<T, object>> Id { get; private set; }
        public Expression<Func<T, object>> Key { get; private set; }
        public Expression<Func<T, object>> Index { get; private set; }
        public Expression<Func<T, object>> Timestamp { get; private set; }

        public DocumentConfiguration(string documentType, Expression<Func<T, object>> id, Expression<Func<T, object>> key, Expression<Func<T, object>> index, Expression<Func<T, object>> timestamp)
        {
            DocumentType = documentType;
            Id = id;
            Key = key;
            Index = index;
            Timestamp = timestamp;
        }

    }
}