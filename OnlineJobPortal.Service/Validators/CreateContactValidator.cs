using FluentValidation;
using OnlineJobPortal.Common.Models.Contact;

namespace OnlineJobPortal.Service.Validators;

public class CreateContactValidator : AbstractValidator<CreateContactModel>
{
    public CreateContactValidator()
    {
        

        RuleFor(x => x.Details)
            .MinimumLength(10)
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber)).WithMessage("Detail's length must be higher than 10");

    }

}
