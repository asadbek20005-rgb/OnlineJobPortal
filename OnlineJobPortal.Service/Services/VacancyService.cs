using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Vacancy;
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
    IBaseRepository<User> userRepository,
    IValidator<VacancyFilterModel> validator1,
    IBaseRepository<Reply> replyRepository) : StatusGenericHandler, IVacancyService
{
    private readonly IBaseRepository<Vacancy> _vacancyRepository = vacancyRepository;
    private readonly IValidator<CreateVacancyModel> _validator = validator;
    private readonly IValidator<VacancyFilterModel> _validator2 = validator1;
    private readonly IMapper _mapper = mapper;
    private readonly IBaseRepository<Company> _companyRepository = companyRepository;
    private readonly IBaseRepository<User> _userRepository = userRepository;
    private readonly IBaseRepository<Reply> _replyRepository = replyRepository;

    #region Ready Actions
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
            .AnyAsync(x => x.id == employerId && x.RoleId == 2);

        if (employerExist is false)
        {
            AddError("No such employer");
            return;
        }


        using var transaction = await _vacancyRepository.BeginTransactionAsync();
        {
            try
            {

                Vacancy vacancy = _mapper.Map<Vacancy>(model);
                vacancy.CompanyId = model.CompanyId;


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
    public async Task<List<VacancyDto>?> GetAllVacanciesBy(VacancyFilterModel model)
    {
        using var transcation = await _vacancyRepository.BeginTransactionAsync();
        try
        {
            var vacancies = await _vacancyRepository.GetAllAsync();
            var validationResult = await _validator2.ValidateAsync(model);
            var dtos = new List<VacancyDto>();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    AddError($"Error: {error}");
                }
                return null;
            }


            if (model.ProfessionId.HasValue)
            {
                dtos = _mapper.Map<List<VacancyDto>>(vacancies.Where(x => x.ProfessionId == model.ProfessionId));
            }

            if (model.CityId.HasValue)
            {
                bool companyExist = await (await _companyRepository.GetAllAsync()).AnyAsync(x => x.CityId == model.CityId);
                if (companyExist)
                {
                    dtos = _mapper.Map<List<VacancyDto>>(vacancies.Where(x => x.Company!.CityId == model.CityId));

                }

            }


            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                bool companyExist = await (await _companyRepository.GetAllAsync()).AnyAsync(x => x.CityId == model.CityId);
                if (companyExist)
                    dtos = _mapper.Map<List<VacancyDto>>(vacancies.Where(x => x.Company!.Name == model.Name));
            }

            if (model.WorkingHourId.HasValue)
            {
                var vacancies1 = await (await _vacancyRepository.GetAllAsync())
                   .Where(v => v.WorkingHourId == model.WorkingHourId)
                   .ToListAsync();

                dtos = _mapper.Map<List<VacancyDto>>(vacancies1);
            }

            if (model.TypeOfEmployemntId.HasValue)
            {
                var vacancies1 = await (await _vacancyRepository.GetAllAsync())
                   .Where(v => v.TypeOfEmploymentId == model.TypeOfEmployemntId)
                   .ToListAsync();

                dtos = _mapper.Map<List<VacancyDto>>(vacancies1);
            }

            await transcation.CommitAsync();
            return dtos;

        }
        catch (Exception ex)
        {
            await transcation.RollbackAsync();
            throw new Exception(ex.Message);
        }

    }
    public async Task AddToFavourites(int vacancyId)
    {
        Vacancy? vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);
        if (vacancy is null)
        {
            AddError("Vacancy Not Found");
            return;
        }

        vacancy.IsFavourite = true;

        await _vacancyRepository.UpdateAsync(vacancy);
        await _vacancyRepository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int vacancyId)
    {
        Vacancy? vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);
        if (vacancy is null)
        {
            AddError("Vacancy Not Found");
            return;
        }
        await _vacancyRepository.DeleteAsync(vacancy);
        await _vacancyRepository.SaveChangesAsync();
    }
    public async Task ReplyAsync(int vacancyId, ReplyModel model)
    {
        var employerReplied = await (await _replyRepository.GetAllAsync()).AnyAsync(x => x.EmployerId == model.EmployerId
        && vacancyId == x.VacancyId);

        if (employerReplied)
        {
            AddError($"Employer with  id:{model.EmployerId} is already replied to this vacancy");
            return;
        }

        var newEmloyer = new Reply
        {
            EmployerId = model.EmployerId,
            VacancyId = vacancyId,
        };

        await _replyRepository.AddAsync(newEmloyer);
        await _replyRepository.SaveChangesAsync();
    }
    public async Task UpdateAsync(int vacancyId, UpdateVacancyModel? model)
    {
        Vacancy? vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);

        if (vacancy is null)
        {
            AddError("Vacancy not Found");
            return;
        }

        Vacancy? updatedVacancy = _mapper.Map(model, vacancy);

        await _vacancyRepository.UpdateAsync(updatedVacancy);
        await _vacancyRepository.SaveChangesAsync();

    }

    #endregion




}