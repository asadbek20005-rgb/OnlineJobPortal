using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.WorkExperiance;

public class UpdateWorkExperianceModel
{
    [StringLength(255)]
    [MinLength(10)]
    public string? CompanyName { get; set; } = string.Empty;

    [DataType(DataType.Url)]
    
    public string? Website { get; set; } = string.Empty;

    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }


    [StringLength(255)]
    public string? JobTitle { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateOnly? GettingStarted { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Ending { get; set; }

    [DataType(DataType.MultilineText)]
    [MinLength(10)]
    public string? Responsibilities { get; set; } = string.Empty;
}
