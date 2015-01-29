namespace DocDb
{
    public class DocumentMetadata
    {
        public int DocumentId { get; private set; }
        public int UpdatedTimestamp { get; private set; }
        public string Key { get; private set; }
        public string Index1 { get; private set; }
        public string Index2 { get; private set; }
        public string Index3 { get; private set; }
        public string ContentHash { get; private set; }

        public DocumentMetadata(int documentId, int updatedTimestamp, string key, string index1, string index2, string index3, string contentHash)
        {
            DocumentId = documentId;
            UpdatedTimestamp = updatedTimestamp;
            Key = key;
            Index1 = index1;
            Index2 = index2;
            Index3 = index3;
            ContentHash = contentHash;
        }
    }
}