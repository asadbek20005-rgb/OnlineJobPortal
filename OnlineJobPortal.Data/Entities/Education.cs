using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("educations", Schema = "application")]
public class Education : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }


    [Column("name")]
    [StringLength(255)]
    [Required]
    public string Name { get; set; } = string.Empty;


    [Column("faculty")]
    [StringLength(255)]
    [Required]
    public string Faculty { get; set; } = string.Empty;


    [Column("graduation_year")]
    [DataType(DataType.Date)]
    [Required]
    public DateOnly GraduationYear { get; set; }

    [Column("level_id")]
    [Required]
    public int LevelId { get; set; }

    [ForeignKey(nameof(LevelId))]
    public Level? Level { get; set; } 
}
