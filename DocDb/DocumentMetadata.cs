namespace DocDb
{
    public class DocumentMetadata
    {
        public int Id { get; private set; }
        public string Key { get; private set; }
        public string Index { get; private set; }
        public int Timestamp { get; private set; }

        public DocumentMetadata(int id, string key, string index, int timestamp)
        {
            Id = id;
            Key = key;
            Index = index;
            Timestamp = timestamp;
        }
    }
}