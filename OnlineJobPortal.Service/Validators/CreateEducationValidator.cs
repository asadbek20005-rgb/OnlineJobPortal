using FluentValidation;
using OnlineJobPortal.Common.Models.Education;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateEducationValidator : AbstractValidator<CreateEducationModel>
{
    public CreateEducationValidator(IBaseRepository<Level> levelRepository)
    {
        RuleFor(x => x.Name)
            .Must(BeAValidName).WithMessage("Enter Valid Name");

        RuleFor(x => x.Faculty)
             .Must(BeAValidName).WithMessage("Enter Valid Faculty");

        RuleFor(x => x.GraduationYear)
            .LessThan(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Graduation year must not be older than the current year.");


        RuleFor(x => x.LevelId)
            .MustAsync(async (levelId, cancel) =>
            {
                Level? level = await levelRepository.GetByIdAsync(levelId);
                if (level is null)
                    return false;
                return true;
            }).WithMessage("No such level");

    }


    private bool BeAValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        if (name.Length <= 3)
            return false;

        if (!char.IsUpper(name[0]))
            return false;

        return true;
    }
}
