using FluentValidation;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateVacancyValidator : AbstractValidator<CreateVacancyModel>
{
    public CreateVacancyValidator(IBaseRepository<City> cityRepository, IBaseRepository<Profession> professionRepository)
    {
        RuleFor(x => x.CreateCompanyModel).SetValidator(new CreateCompanyValidator(cityRepository));
        RuleFor(x => x.ProfessionId)
            .MustAsync(async (professionId, cancel) =>
            {
                if (await professionRepository.GetByIdAsync(professionId) is null)
                    return false;
                return true;
            }).WithMessage("No such profession");
    }
}
