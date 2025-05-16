using FluentValidation;
using OnlineJobPortal.Common.Models.User;

namespace OnlineJobPortal.Service.Validators;

public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {


        RuleFor(x => x.Password)
            .Must(x => x.Any(char.IsUpper)).WithMessage("Password must have 1 upper letter")
            .Must(x => x.Any(char.IsDigit)).WithMessage("Password must have 1 digit")
            .Must(x => x.Any(char.IsLower)).WithMessage("Password must have 1 lower letter");
    }

  
}
