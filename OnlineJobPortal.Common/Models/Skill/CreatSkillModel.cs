using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Skill;

public class CreatSkillModel
{

    [Required]
    public int SkillId { get; set; }

    public int? LevelId { get; set; }
}
