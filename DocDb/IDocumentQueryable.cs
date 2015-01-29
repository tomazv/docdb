namespace DocDb
{
    public interface IDocumentQueryable<out T>
    {
        T[] GetDocuments(DocumentQuery query);
        DocumentMetadata[] GetDocumentMetadata(DocumentQuery query);
    }
}