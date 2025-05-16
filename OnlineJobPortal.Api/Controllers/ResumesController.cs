using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Extensions;

namespace OnlineJobPortal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumesController(IResumeService resumeService) : ControllerBase
{
    private readonly IResumeService _resumeService = resumeService;

    [HttpPost("/api/Users/{userId:guid}/[controller]")]
    public async Task<IActionResult> Create(Guid userId, CreateResumeModel model)
    {
        await _resumeService.CreateAsync(userId, model);
        if (_resumeService.IsValid)
        {
            return Ok("done");
        }
        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }


    [HttpPut("/api/Users/{userId:guid}/[controller]/{resumeId:int}/delete-perminantly")]
    public async Task<IActionResult> DeletePerminantly(Guid userId, int resumeId)
    {
        await _resumeService.DeletePerminanlyAsync(userId, resumeId);
        if (_resumeService.IsValid)
            return Ok("Done");
        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPut("/api/Users/{userId:guid}/[controller]/{resumeId:int}/hide")]
    public async Task<IActionResult> HideResume(Guid userId, int resumeId)
    {
        await _resumeService.HideAsync(userId, resumeId);
        if (_resumeService.IsValid)
            return Ok("Done");
        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }



    [HttpGet]
    public async Task<IActionResult> GetAllResumes()
    {
        List<ResumeDto> resumes = await _resumeService.GetAllResumesAsync();
        if (_resumeService.IsValid)
            return Ok(resumes);

        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }


    [HttpGet("/api/Users/{userId:guid}/[controller]")]
    public async Task<IActionResult> GetAllUserResumes(Guid userId)
    {
        List<ResumeDto> resumes = await _resumeService.GetAllUserResumes(userId);
        if (_resumeService.IsValid)
            return Ok(resumes);

        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }


    [HttpGet("/api/Users/{userId:guid}/[controller]/{resumeId:int}")]
    public async Task<IActionResult> GetUserResumeById(Guid userId, int resumeId)
    {
        ResumeDto? resume = await _resumeService.GetUserResumeByIdAsync(userId, resumeId);
        if (_resumeService.IsValid)
            return Ok(resume);

        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPut("/api/Users/{userId:guid}/[controller]/{resumeId:int}")]
    public async Task<IActionResult> Edit(Guid userId, int resumeId, UpdateResumeModel model)
    {
        await _resumeService.EditAsync(userId, resumeId, model);
        if (_resumeService.IsValid)
            return Ok("done");
        _resumeService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }



}