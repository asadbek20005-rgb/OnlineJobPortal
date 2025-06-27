using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Company;
using OnlineJobPortal.Data.Entities;
using StatusGeneric;

namespace OnlineJobPortal.Service.Contracts;

public interface ICompanyService : IStatusGeneric
{
    Task<List<CompanyDto>> GetCompanies();
    Task<List<CompanyDto>> GetCompaniesBy(FilterCompanyModel model);
    Task<CompanyDto?> GetCompanyById(int id);
    Task AddCompany(CreateCompanyModel model);
    Task UpdateCompany(int id, UpdateCompanyModel model);
    Task DeleteCompany(int id);

}