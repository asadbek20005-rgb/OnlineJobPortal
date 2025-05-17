using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Extensions;

namespace OnlineJobPortal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContentsController(IContentService contentService) : ControllerBase
{
    private readonly IContentService _contentService = contentService;

    [HttpPost("/api/Users/profile/img")]
    public async Task<IActionResult> UploadFile(Guid userId, IFormFile file)
    {
        string fileName = await _contentService.UploadImgAsync(userId, file);
        if (_contentService.IsValid)
            return Ok(fileName);
        _contentService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }


    [HttpGet("/api/Users/profile/img")]
    public async Task<IActionResult> DownloadFile(Guid userId, string fileName)
    {
        Stream? stream = await _contentService.DownloadImgAsync(userId, fileName);
        if (_contentService.IsValid)
            return Ok(stream);

        _contentService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }


}
