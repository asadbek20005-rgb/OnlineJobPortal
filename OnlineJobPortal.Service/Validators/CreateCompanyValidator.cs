using FluentValidation;
using OnlineJobPortal.Common.Models.Company;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyModel>
{
    public CreateCompanyValidator(IBaseRepository<City> cityRepository)
    {
        RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Company name must be at least 2")
            .Must(BeAValidName).WithMessage("Invalid company name");

        RuleFor(x => x.CityId)
            .MustAsync(async (cityId, cancel) =>
            {
                if (await cityRepository.GetByIdAsync(cityId) is null)
                    return false;
                return true;
            }).WithMessage("No such city");
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
