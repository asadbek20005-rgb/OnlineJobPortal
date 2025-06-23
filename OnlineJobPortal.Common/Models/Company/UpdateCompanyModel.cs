using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Company;

public class UpdateCompanyModel
{
    [StringLength(255)]
    public string? Name { get; set; } = string.Empty;

    [DataType(DataType.MultilineText)]
    public string? About { get; set; } = string.Empty;
    public int? CityId { get; set; }
}