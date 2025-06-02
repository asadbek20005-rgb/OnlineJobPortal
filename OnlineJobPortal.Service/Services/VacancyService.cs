using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Common.Statics;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using StatusGeneric;

namespace OnlineJobPortal.Service.Services;

public class VacancyService(
    IBaseRepository<Vacancy> vacancyRepository,
    IValidator<CreateVacancyModel> validator,
    IMapper mapper,
    IBaseRepository<Company> companyRepository,
    IBaseRepository<User> userRepository) : StatusGenericHandler, IVacancyService
{
    private readonly IBaseRepository<Vacancy> _vacancyRepository = vacancyRepository;
    private readonly IValidator<CreateVacancyModel> _validator = validator;
    private readonly IMapper _mapper = mapper;
    private readonly IBaseRepository<Company> _companyRepository = companyRepository;
    private readonly IBaseRepository<User> _userRepository = userRepository;
    public async Task CreateAsync(Guid employerId, CreateVacancyModel model)
    {
        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError($"Errors: {error.ErrorMessage}");
            }
            return;
        }

        bool employerExist = await (await _userRepository.GetAllAsync())
            .AnyAsync(x => x.id == employerId && x.RoleId == StaticData.Holder);

        if (employerExist is false)
        {
            AddError("No such employer");
            return;
        }


        using var transaction = await _vacancyRepository.BeginTransactionAsync();
        {
            try
            {
                Company company = _mapper.Map<Company>(model.CreateCompanyModel);
                await _companyRepository.AddAsync(company);
                await _companyRepository.SaveChangesAsync();

                Vacancy vacancy = _mapper.Map<Vacancy>(model);
                vacancy.CompanyId = company.Id;

                await _vacancyRepository.AddAsync(vacancy);
                await _vacancyRepository.SaveChangesAsync();
                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

    }

    public async Task<List<VacancyDto>> GetAll()
    {
        List<Vacancy> vacancies = await (await _vacancyRepository.GetAllAsync()).ToListAsync();

        return _mapper.Map<List<VacancyDto>>(vacancies);
    }
}
  