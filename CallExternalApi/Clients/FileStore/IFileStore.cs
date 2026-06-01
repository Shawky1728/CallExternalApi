using Refit;

namespace CallExternalApi.Clients.FileStore
{
    public interface IFileStore
    {
        [Multipart]
        [Post("/api/files/upload")]
        Task Upload([AliasAs("File")] StreamPart stream); // streamPart is a class from Refit

        [Multipart]
        [Post("/api/files/upload-many")]
        Task UploadManyAsync([AliasAs("Files")] IEnumerable<StreamPart> streams); 
    }
}
