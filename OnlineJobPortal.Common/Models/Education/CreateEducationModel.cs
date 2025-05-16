using System.ComponentModel.DataAnnotations;
namespace OnlineJobPortal.Common.Models.Education;

public class CreateEducationModel
{
    [StringLength(255)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [StringLength(255)]
    [Required]
    public string Faculty { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Required]
    public DateOnly GraduationYear { get; set; }

    [Required]
    public int LevelId { get; set; }

}