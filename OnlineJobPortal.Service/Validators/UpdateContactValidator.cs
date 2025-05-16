using FluentValidation;
using OnlineJobPortal.Common.Models.Contact;

namespace OnlineJobPortal.Service.Validators;

public class UpdateContactValidator : AbstractValidator<UpdateContactModel>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.PhoneNumber).Must(BeAValidPhoneNumber)
            .When(model => !string.IsNullOrEmpty(model.PhoneNumber)).WithMessage("Invalid phone number");


        RuleFor(x => x.Details)
            .MinimumLength(10)
            .When(x => !string.IsNullOrWhiteSpace(x.Details)).WithMessage("Detail's length must be higher than 10");
    }
    private bool BeAValidPhoneNumber(string? phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) return false;

        if (phoneNumber.StartsWith("+998")) return false;

        return true;
    }
}
