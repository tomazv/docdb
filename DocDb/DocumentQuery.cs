namespace DocDb
{
    public class DocumentQuery
    {
        public int? Id { get; private set; }
        public string Key { get; private set; }
        public string Index { get; private set; }
        public int? Timestamp { get; private set; }

        private DocumentQuery Clone()
        {
            return new DocumentQuery
            {
                Id = Id,
                Key = Key,
                Index = Index,
                Timestamp = Timestamp
            };
        }

        public DocumentQuery WithDocumentId(int? id)
        {
            DocumentQuery clone = Clone();
            clone.Id = id;
            return clone;
        }

        public DocumentQuery WithKey(string key)
        {
            DocumentQuery clone = Clone();
            clone.Key = key;
            return clone;
        }

        public DocumentQuery WithIndex(string index)
        {
            DocumentQuery clone = Clone();
            clone.Index = index;
            return clone;
        }

        public DocumentQuery WithTimestamp(int? timestamp)
        {
            DocumentQuery clone = Clone();
            clone.Timestamp = timestamp;
            return clone;
        }
    }
}