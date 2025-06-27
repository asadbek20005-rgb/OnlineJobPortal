using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Company;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using StatusGeneric;

namespace OnlineJobPortal.Service.Services;

public class CompanyService(
    IBaseRepository<Company> companyRepository,
    IValidator<CreateCompanyModel> createValidator,
    IMapper mapper,
    IValidator<UpdateCompanyModel> updateValidator) : StatusGenericHandler, ICompanyService
{
    private readonly IBaseRepository<Company> _companyRepository = companyRepository;
    private readonly IValidator<CreateCompanyModel> _createValidator = createValidator;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdateCompanyModel> _updateValidator = updateValidator;
    public async Task AddCompany(CreateCompanyModel model)
    {
        bool companyExist = await (await _companyRepository.GetAllAsync())
            .AnyAsync(x => x.Name == model.Name);

        if (companyExist)
        {
            AddError($"Company with {model.Name} is already exist");
            return;
        }

        var validationResult = await _createValidator.ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError($"Error: {error.ErrorMessage}");
            }
            return;
        }

        var newCompany = _mapper.Map<Company>(model);

        await _companyRepository.AddAsync(newCompany);
        await _companyRepository.SaveChangesAsync();

    }

    public async Task DeleteCompany(int id)
    {
        Company? company = await _companyRepository.GetByIdAsync(id);
        if (company is null)
        {
            AddError("Company Not Found");
            return;
        }

        await _companyRepository.DeleteAsync(company);
        await _companyRepository.SaveChangesAsync();
    }

    public async Task<List<CompanyDto>> GetCompanies()
    {
        var companies = await _companyRepository.GetAllAsync();

        return _mapper.Map<List<CompanyDto>>(companies);
    }

    public Task<List<CompanyDto>> GetCompaniesBy(FilterCompanyModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<CompanyDto?> GetCompanyById(int id)
    {
        Company? company = await _companyRepository.GetByIdAsync(id);
        if (company is null)
        {
            AddError("Company Not Found");
            return null;
        }

        return _mapper.Map<CompanyDto>(company);

    }

    public async Task UpdateCompany(int id, UpdateCompanyModel model)
    {

        Company? company = await _companyRepository.GetByIdAsync(id);
        if (company is null)
        {
            AddError("Company Not Found");
            return;
        }

        var validationResult = await _updateValidator.ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError($"Error: {error.ErrorMessage}");
            }
            return;
        }

        var updatedCompany = _mapper.Map(model, company);



        await _companyRepository.UpdateAsync(updatedCompany);
        await _companyRepository.SaveChangesAsync();
    }
}
