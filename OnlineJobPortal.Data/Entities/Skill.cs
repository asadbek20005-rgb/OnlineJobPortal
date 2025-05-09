using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("info_skills", Schema = "info")]
public class Skill : BaseEntity
{
    [Column("level_id")]
    public int? LevelId { get; set; }

    [ForeignKey(nameof(LevelId))]
    public Level? Level { get; set; } 
}
