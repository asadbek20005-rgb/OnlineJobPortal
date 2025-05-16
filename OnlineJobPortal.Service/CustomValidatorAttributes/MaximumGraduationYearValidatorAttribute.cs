using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Service.CustomValidatorAttributes;

public class MaximumGraduationYearValidatorAttribute : ValidationAttribute
{
    public DateOnly MaximumYear { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public MaximumGraduationYearValidatorAttribute(DateOnly maxYear)
    {
        MaximumYear = maxYear;
    }


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        return base.IsValid(value, validationContext);
    }



}
