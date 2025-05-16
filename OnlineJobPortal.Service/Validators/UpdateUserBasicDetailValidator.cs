using FluentValidation;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class UpdateUserBasicDetailValidator : AbstractValidator<UpdateUserBasicDetailModel>
{
    public UpdateUserBasicDetailValidator(IBaseRepository<City> cityRepository,
        IBaseRepository<Status> statusRepository,
        IBaseRepository<Language> languageRepository,
        IBaseRepository<Level> levelRepository)
    {
        RuleFor(x => x.FullName)
          .Must(BeAValidFullName).WithMessage("Please enter your full name (first and last name).")
          .When(x => !string.IsNullOrEmpty(x.FullName));


        RuleFor(x => x.CityId)
            .MustAsync(async (cityId, cancellation) =>
            {
                City? city = await cityRepository.GetByIdAsync(cityId);
                if (city is null)
                    return false;
                return true;
            }).WithMessage("No such city")
            .When(x => x.CityId.HasValue);



        RuleFor(x => x.StatusId)
            .MustAsync(async (statusId, cancellation) =>
            {
                Status? status = await statusRepository.GetByIdAsync(statusId);
                if (status is null)
                    return false;
                return true;
            }).WithMessage("No such status")
            .When(x => x.StatusId.HasValue);

        RuleFor(x => x.LanguageId)
            .MustAsync(async (languageId, cancel) =>
            {
                Language? language = await languageRepository.GetByIdAsync(languageId);
                if (language is null) return false;
                return true;
            }).WithMessage("No such language").When(x => x.LanguageId.HasValue);


        RuleFor(x => x.LevelId)
            .MustAsync(async (languageId, cancel) =>
            {
                Level? level = await levelRepository.GetByIdAsync(languageId);
                if (level is null) return false;
                return true;
            }).WithMessage("No such level").When(x => x.LevelId.HasValue);
    }


    private bool BeAValidFullName(string? fullName)
    {
        if (string.IsNullOrEmpty(fullName))
            return false;

        var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return false;

        return parts.All(part => part.Length >= 2 && part.All(char.IsLetter));
    }
}