using FluentValidation;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateUserBasicDetailValidator : AbstractValidator<CreateUserBasicDetailModel>
{
    public CreateUserBasicDetailValidator(IBaseRepository<City> cityRepository, IBaseRepository<Status> statusRepository)
    {
        RuleFor(x => x.FullName)
           .Must(BeAValidFullName).WithMessage("Please enter your full name (first and last name).");

        RuleFor(x => x.CityId)
            .MustAsync(async (cityId, cancellation) =>
            {
                City? city = await cityRepository.GetByIdAsync(cityId);
                if (city is null)
                    return false;
                return true;
            }).WithMessage("No such city");


        RuleFor(x => x.StatusId)
            .MustAsync(async (statusId, cancellation) =>
            {
                Status? status = await statusRepository.GetByIdAsync(statusId);
                if (status is null)
                    return false;
                return true;
            }).WithMessage("No such city");


    }

    private bool BeAValidFullName(string fullName)
    {
        if (string.IsNullOrEmpty(fullName))
            return false;

        var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return false;

        return parts.All(part => part.Length >= 2 && part.All(char.IsLetter));
    }

}
