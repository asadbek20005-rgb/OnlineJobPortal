using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.Company;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyModel>
{
    public UpdateCompanyValidator(IBaseRepository<Company> _companyRepositor)
    {
        RuleFor(x => x.CityId)
            .MustAsync(async (cityId, cancel) =>
            {
                return await (await _companyRepositor.GetAllAsync()).AnyAsync(x => x.CityId == cityId);
            }).WithMessage("Invalid City Id").When(x => x.CityId.HasValue);

        RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Company name must be at least 2")
            .Must(BeAValidName).WithMessage("Invalid company name").When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.About)
            .NotEmpty()
            .NotNull()
            .MaximumLength(255)
            .MinimumLength(10)
            .When(x => !string.IsNullOrWhiteSpace(x.About));

    }

    private bool BeAValidName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        if (!char.IsUpper(name[0]))
            return false;

        return true;
    }
}
