using FluentValidation;
using OnlineJobPortal.Common.Models.WorkExperiance;

namespace OnlineJobPortal.Service.Validators;

public class UpdateWorkExperianceValidator : AbstractValidator<UpdateWorkExperianceModel>
{
    public UpdateWorkExperianceValidator()
    {
        RuleFor(x => x.GettingStarted)
        .LessThanOrEqualTo(x => x.Ending).When(x => x.GettingStarted.HasValue).WithMessage("Start date must be before or equal to end date.");

        RuleFor(x => x.Ending)
           .NotEmpty().WithMessage("End date is required.")
           .GreaterThanOrEqualTo(x => x.GettingStarted)
           .When(x => x.Ending.HasValue)
           .WithMessage("End date must be after or equal to start date.");


        RuleFor(x => x.Responsibilities)
           .MinimumLength(10)
           .When(x => !string.IsNullOrEmpty(x.Responsibilities))
           .WithMessage("Responsibilities should be at least 10 characters long.");


        RuleFor(x => x.Details)
            .MaximumLength(1000).WithMessage("Details must be at most 1000 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Details));

        RuleFor(x => x.Website)
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                         && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            .When(x => !string.IsNullOrEmpty(x.Website))
            .WithMessage("Website must be a valid URL.");
    }
}
