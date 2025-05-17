using Microsoft.AspNetCore.Http;
using StatusGeneric;

namespace OnlineJobPortal.Service.Contracts;

public interface IContentService : IStatusGeneric
{
    Task<string> UploadImgAsync(Guid userId, IFormFile file);
    Task<Stream?> DownloadImgAsync(Guid userId, string fileName);
}
