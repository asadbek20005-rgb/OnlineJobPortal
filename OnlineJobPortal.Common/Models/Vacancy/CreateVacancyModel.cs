using OnlineJobPortal.Common.Models.Company;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Vacancy;

public class CreateVacancyModel
{
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int ProfessionId { get; set; }

    [DataType(DataType.MultilineText)]
    [Required]
    [MinLength(150, ErrorMessage = "About must be at least 150 letter")]
    public string Responsibilities { get; set; } = string.Empty;


    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }
}
