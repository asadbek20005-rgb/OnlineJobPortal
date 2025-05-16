using FluentValidation;
using OnlineJobPortal.Common.Models.WorkExperiance;

namespace OnlineJobPortal.Service.Validators;

public class CreateWokrExperianceValidator : AbstractValidator<CreateWorkExperianceModel>
{
    public CreateWokrExperianceValidator()
    {
        RuleFor(x => x.GettingStarted)
        .LessThanOrEqualTo(x => x.Ending).WithMessage("Start date must be before or equal to end date.");

        RuleFor(x => x.Ending)
           .NotEmpty().WithMessage("End date is required.")
           .GreaterThanOrEqualTo(x => x.GettingStarted).WithMessage("End date must be after or equal to start date.");


        RuleFor(x => x.Responsibilities)
           .NotEmpty().WithMessage("Responsibilities are required.")
           .MinimumLength(10).WithMessage("Responsibilities should be at least 10 characters long.");


        RuleFor(x => x.Details)
            .MaximumLength(1000).WithMessage("Details must be at most 1000 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Details));

        RuleFor(x => x.Website)
            .NotEmpty().WithMessage("Website is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                         && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            .WithMessage("Website must be a valid URL.");
    }


}
