using FluentValidation;
using OnlineJobPortal.Common.Models.Otp;

namespace OnlineJobPortal.Service.Validators;

public class VerifyRegisterValidator : AbstractValidator<OtpModel>
{
    public VerifyRegisterValidator()
    {
        RuleFor(x => x.PhoneNumber)
           .Must(BeAValidPhoneNumber)
           .WithMessage("Invalid phone number");

    }


    private bool BeAValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) return false;

        if (!phoneNumber.StartsWith("+998")) return false;

        return true;
    }
}
