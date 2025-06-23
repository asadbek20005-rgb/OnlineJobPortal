using Microsoft.AspNetCore.Mvc;
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
}
