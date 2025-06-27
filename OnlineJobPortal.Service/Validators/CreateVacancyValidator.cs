using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateVacancyValidator : AbstractValidator<CreateVacancyModel>
{
    public CreateVacancyValidator(IBaseRepository<Company> _companyRepository, IBaseRepository<Profession> professionRepository)
    {
        RuleFor(x => x.ProfessionId)
            .MustAsync(async (professionId, cancel) =>
            {
                if (await professionRepository.GetByIdAsync(professionId) is null)
                    return false;
                return true;
            }).WithMessage("No such profession");


        RuleFor(x => x.CompanyId)
            .NotEmpty()
            .NotNull()
            .MustAsync(async (companyId, cancel) =>
            {
                return await (await _companyRepository.GetAllAsync()).AnyAsync(x => x.Id == companyId);
            }).WithMessage("Invalid Company Id");
    }
}
