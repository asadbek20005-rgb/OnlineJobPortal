using Minio;
using Minio.DataModel.Args;
using OnlineJobPortal.Common.Models.Minio;
using OnlineJobPortal.Service.Contracts;
using System.Text.RegularExpressions;

namespace OnlineJobPortal.Service.Services;

public class MinioService : IMinioService
{
    private readonly MinioClient _minioClient;
    private string minioUrl = "http://localhost:9000";
    private const string bucket = "mybucketonlinejobportal";
    public MinioService(MinioSettings model)
    {
        _minioClient = (MinioClient)new MinioClient()
            .WithEndpoint(model.Endpoint)
            .WithCredentials(model.AccessKey, model.SecretKey)
            .Build();
    }

    public async Task UploadFileAsync(string fileName, string contentType, long size, Stream data)
    {
        if (data.CanSeek)
        {
            data.Seek(0, SeekOrigin.Begin);
        }
        await EnsureBucketExistsAsync();

        await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(bucket)
                .WithObject(fileName)
                .WithStreamData(data)
                .WithObjectSize(size)
                .WithContentType(contentType));
    }

    private async Task EnsureBucketExistsAsync()
    {

        bool result = IsValidBucketName(bucket);
        if (!result)
            throw new Exception("Bucket validation failed");

        var found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket));

        if (!found)
        {
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucket));
        }
        else
            return;
    }


    private static bool IsValidBucketName(string bucketName)
    {
        string pattern = @"^[a-z0-9][a-z0-9.-]{1,61}[a-z0-9]$";
        return Regex.IsMatch(bucketName, pattern);
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        await EnsureBucketExistsAsync();
        var ms = new MemoryStream();
        await _minioClient.GetObjectAsync(new GetObjectArgs()
            .WithBucket(bucket)
            .WithObject(fileName)
            .WithCallbackStream(async stream =>
            {
                await stream.CopyToAsync(ms);
            }));
        ms.Position = 0;
        return ms;
    }
}