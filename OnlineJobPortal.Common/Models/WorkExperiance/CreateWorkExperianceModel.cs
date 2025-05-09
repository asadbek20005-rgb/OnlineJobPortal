using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.WorkExperiance;

public class CreateWorkExperianceModel
{
    [StringLength(255)]
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [DataType(DataType.Url)]
    [Required]
    public string Website { get; set; } = string.Empty;


    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }


    [StringLength(255)]
    [Required]
    public string JobTitle { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Required]
    public DateOnly GettingStarted { get; set; }


    [DataType(DataType.Date)]
    [Required]
    public DateOnly Ending { get; set; }


    [DataType(DataType.MultilineText)]
    [Required]
    public string Responsibilities { get; set; } = string.Empty;
}
