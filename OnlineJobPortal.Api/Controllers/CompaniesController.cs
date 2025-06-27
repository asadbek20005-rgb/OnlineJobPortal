using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Common.Models.Company;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Extensions;

namespace OnlineJobPortal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyModel model)
    {
        await _companyService.AddCompany(model);

        if (_companyService.IsValid)
            return Ok("done");

        _companyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companyService.GetCompanies();

        if (_companyService.IsValid)
            return Ok(companies);

        _companyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        var company = await _companyService.GetCompanyById(id);


        if (_companyService.IsValid)
            return Ok(company);

        _companyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCompanyModel model)
    {
        await _companyService.UpdateCompany(id, model);

        if (_companyService.IsValid)
            return Ok("done");

        _companyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _companyService.DeleteCompany(id);
        if (_companyService.IsValid)
            return Ok("done");

        _companyService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }
}