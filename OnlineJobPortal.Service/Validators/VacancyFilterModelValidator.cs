using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class VacancyFilterModelValidator : AbstractValidator<VacancyFilterModel>
{
    
    public VacancyFilterModelValidator(IBaseRepository<Profession> professionRepository,
        IBaseRepository<City> cityRepository)
    {
        RuleFor(x => x.ProfessionId)
            .MustAsync(async (professionId, cancel) =>
            {
                return await (await professionRepository.GetAllAsync()).AnyAsync(x => x.Id == professionId);
            }).WithMessage("Invalid profession id").When(x => x.ProfessionId.HasValue);

        RuleFor(x => x.CityId)
            .MustAsync(async (cityId, cancel) =>
            {
                return await (await cityRepository.GetAllAsync()).AnyAsync(city => city.Id == cityId);
            }).WithMessage("Invalid city id").When(x => x.CityId.HasValue);
    }


}