using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Education;

public class UpdateEducationModel
{
    [StringLength(255)]
    public string? Name { get; set; } = string.Empty;
    [StringLength(255)]
    public string? Faculty { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateOnly? GraduationYear { get; set; }

    public int? LevelId { get; set; }
}
