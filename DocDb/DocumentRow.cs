namespace DocDb
{
    public class DocumentRow
    {
        public string Content { get; private set; }
        public DocumentMetadata Metadata { get; private set; }

        public DocumentRow(string content, DocumentMetadata metadata)
        {
            Content = content;
            Metadata = metadata;
        }
    }
}