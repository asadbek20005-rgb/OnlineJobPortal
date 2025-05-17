namespace OnlineJobPortal.Service.Contracts;

public interface IMinioService
{
    Task UploadFileAsync(string fileName, string contentType, long size, Stream data);
    Task<Stream> DownloadFileAsync(string fileName);
}
