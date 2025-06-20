using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Company;

public class CreateCompanyModel
{
    [StringLength(255)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.MultilineText)]
    [Required]
    public string About { get; set; } = string.Empty;

    [Required]
    public int CityId { get; set; }
}