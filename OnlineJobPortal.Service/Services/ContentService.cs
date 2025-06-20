using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Results;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using StatusGeneric;

namespace OnlineJobPortal.Service.Services;

public class ContentService(
    IUserService userService,
    IBaseRepository<Content> contentRepository,
    IMinioService minioService) : StatusGenericHandler, IContentService
{
    private readonly IUserService _userService = userService;
    private readonly IBaseRepository<Content> _contentRepository = contentRepository;
    private readonly IMinioService _minioService = minioService;

    public async Task<Stream?> DownloadImgAsync(Guid userId, string fileName)
    {
        Result<UserDto> user = await _userService.GetProfileAsync(userId);
        if (user.Data is null)
        {
            AddError("User not found");
            return null;
        }

        bool contentExist = await (await _contentRepository.GetAllAsync())
            .AnyAsync(x => x.FileName == fileName);

        if (contentExist is false)
        {
            AddError("Content Not Found");
            return null;
        }

        Stream stream = await _minioService.DownloadFileAsync(fileName);
        return stream;
    }


    public async Task<string> UploadImgAsync(Guid userId, IFormFile file)
    {
        Result<UserDto> user = await _userService.GetProfileAsync(userId);
        if (user.Data is null)
        {
            AddError("User not found");
            return string.Empty;
        }

        var (filename, contentType, size, data) = await SaveFileDetails(file);

        await _minioService.UploadFileAsync(filename, contentType, size, data);

        Content newContent = new Content
        {
            FileName = filename,
            ContentType = contentType,
            UserId = user.Data.id,
        };

        await _contentRepository.AddAsync(newContent);
        await _contentRepository.SaveChangesAsync();
        return filename;
    }


    private async Task<(string FileName, string ContentType, long Size, MemoryStream Data)> SaveFileDetails(IFormFile file)
    {
        var fileName = Guid.NewGuid().ToString();
        string contentType = file.ContentType;
        long size = file.Length;

        var data = new MemoryStream();
        await file.CopyToAsync(data);

        return (fileName, contentType, size, data);
    }


}
