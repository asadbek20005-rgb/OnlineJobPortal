namespace OnlineJobPortal.Common.Models.Minio;

public class UploadFileModel
{
    public string ObjectName { get; set; }
    public string ContentType { get; set; }
    public Stream Stream { get; set; }
    public long Size { get; set; }
}
