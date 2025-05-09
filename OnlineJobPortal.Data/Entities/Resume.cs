using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("resumes", Schema = "application")]
public class Resume : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }


    [Column("profession_id")]
    [Required]
    public int ProfessionId { get; set; }


    [ForeignKey(nameof(ProfessionId))]
    public Profession? Profession { get; set; } = null!;


    [Column("working_hour_id")]
    [Required]
    public int WorkingHourId { get; set; }

    [ForeignKey(nameof(WorkingHourId))]
    public WorkingHour? WorkingHour { get; set; } = null!;


    [Column("currency_id")]
    [Required]
    public int CurrencyId { get; set; }

    [ForeignKey(nameof(CurrencyId))]
    public Currency? Currency { get; set; } = null!;


    [Column("type_of_employment_id")]
    [Required]
    public int TypeOfEmploymentId { get; set; } 

    [ForeignKey(nameof(TypeOfEmploymentId))]
    public TypeOfEmployment? TypeOfEmployment { get; set; } = null!;


    [Column("contact_id")]
    [Required]
    public int ContactId { get; set; }

    [ForeignKey(nameof(ContactId))]
    public Contact? Contact { get; set; } = null!;


    [Column("work_experiance_id")]
    [Required]
    public int WorkExperianceId { get; set; }

    [ForeignKey(nameof(WorkExperianceId))]
    public WorkExperience? WorkExperiance { get; set; } = null!;

    [Column("education_id")]
    [Required]
    public int EducationId { get; set; }

    [ForeignKey(nameof(EducationId))]
    public Education? Education { get; set; } = null!;


    [Column("skill_id")]
    [Required]
    public int SkillId { get; set; }

    [ForeignKey(nameof(SkillId))]
    public Skill? Skill { get; set; } = null!;


    [Column("user_id")]
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; } = null!;


    [Column("income_level_per_month")]
    [Required]
    public decimal IncomeLevelPerMonth { get; set; }


    [Column("specializations")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string Specializations { get; set; } = string.Empty;



    [Column("about_me")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string AboutMe { get; set; } = string.Empty;

}
