using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Extensions;

namespace OnlineJobPortal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacanciesController(IVacancyService vacancyService) : ControllerBase
{
    private readonly IVacancyService _vacancyService = vacancyService;
    [HttpPatch("{vacancyId:int}/make-favourite")]
    public async Task<IActionResult> AddToFavourites(int vacancyId)
    {
        await _vacancyService.AddToFavourites(vacancyId);
        if (_vacancyService.IsValid)
        {
            return Ok("Added");
        }

        _vacancyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }



    [HttpDelete("{vacancyId:int}")]
    public async Task<IActionResult> Delete(int vacancyId)
    {
        await _vacancyService.DeleteAsync(vacancyId);

        if (_vacancyService.IsValid)
        {
            return Ok("done");
        }

        _vacancyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }


    [HttpPost("{vacancyId:int}/reply")]
    public async Task<IActionResult> Reply(int vacancyId, ReplyModel model)
    {
        await _vacancyService.ReplyAsync(vacancyId, model);
        if (_vacancyService.IsValid)
        {
            return Ok("Done");
        }

        _vacancyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPut("{vacancyId:int}")]
    public async Task<IActionResult> Update(int vacancyId, UpdateVacancyModel? model)
    {
        await _vacancyService.UpdateAsync(vacancyId, model);
        if (_vacancyService.IsValid)
        {
            return Ok("Done");
        }

        _vacancyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }
}
