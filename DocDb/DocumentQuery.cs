namespace DocDb
{
    public class DocumentQuery
    {
        public int? DocumentId { get; private set; }
        public int? UpdatedTimestamp { get; private set; }
        public string Key { get; private set; }
        public string Index1 { get; private set; }
        public string Index2 { get; private set; }
        public string Index3 { get; private set; }

        private DocumentQuery Clone()
        {
            return new DocumentQuery
            {
                DocumentId = DocumentId,
                UpdatedTimestamp = UpdatedTimestamp,
                Key = Key,
                Index1 = Index1,
                Index2 = Index2,
                Index3 = Index3
            };
        }

        public DocumentQuery WithDocumentId(int? documentId)
        {
            DocumentQuery clone = Clone();
            clone.DocumentId = documentId;
            return clone;
        }

        public DocumentQuery WithUpdatedTimestamp(int? updatedTimestamp)
        {
            DocumentQuery clone = Clone();
            clone.UpdatedTimestamp = updatedTimestamp;
            return clone;
        }

        public DocumentQuery WithKey(string key)
        {
            DocumentQuery clone = Clone();
            clone.Key = key;
            return clone;
        }

        public DocumentQuery WithIndex1(string index1)
        {
            DocumentQuery clone = Clone();
            clone.Index1 = index1;
            return clone;
        }

        public DocumentQuery WithIndex2(string index2)
        {
            DocumentQuery clone = Clone();
            clone.Index2 = index2;
            return clone;
        }

        public DocumentQuery WithIndex3(string index3)
        {
            DocumentQuery clone = Clone();
            clone.Index3 = index3;
            return clone;
        }
    }
}