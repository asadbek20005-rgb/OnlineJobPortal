using FluentValidation;
using OnlineJobPortal.Common.Models.Education;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class UpdateEducationValidator : AbstractValidator<UpdateEducationModel>
{
    public UpdateEducationValidator(IBaseRepository<Level> levelRepository)
    {
        RuleFor(x => x.Name)
           .Must(BeAValidName).
           When(x => !string.IsNullOrEmpty(x.Name))
           .WithMessage("Enter Valid Name");
            
        RuleFor(x => x.Faculty)
             .Must(BeAValidName)
             .When(x => !string.IsNullOrEmpty(x.Faculty))
             .WithMessage("Enter Valid Faculty");

        RuleFor(x => x.GraduationYear)
            .LessThan(DateOnly.FromDateTime(DateTime.UtcNow)).When(x => x.GraduationYear.HasValue)
            .WithMessage("Graduation year must not be older than the current year.");


        RuleFor(x => x.LevelId)
            .MustAsync(async (levelId, cancel) =>
            {
                Level? level = await levelRepository.GetByIdAsync(levelId);
                if (level is null)
                    return false;
                return true;
            }).When(x => x.LevelId.HasValue).WithMessage("No such level");
    }

    private bool BeAValidName(string? name)
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
