using OnlineJobPortal.Common.Models.Contact;
using OnlineJobPortal.Common.Models.Education;
using OnlineJobPortal.Common.Models.Skill;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Common.Models.WorkExperiance;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Resume;

public class CreateResumeModel
{

    [Required]
    public CreateUserBasicDetailModel CreateUserBasicDetail { get; set; }

    [Required]
    public int ProfessionId { get; set; }


    [Required]
    public decimal IncomeLevelPerMonth { get; set; }

    [Required]
    public int CurrencyId { get; set; }

    [DataType(DataType.MultilineText)]
    [Required]
    public string Specializations { get; set; } = string.Empty;


    [Required]
    public CreateEducationModel Education { get; set; }


    [Required]
    public CreatSkillModel CreatSkill { get; set; }


    [Required]
    public CreateWorkExperianceModel CreateWorkExperiance { get; set; }

    [Required]
    public int WorkingHourId { get; set; }

    [Required]
    public int TypeOfEmploymentId { get; set; }


    [Required]
    public CreateContactModel CreateContact { get; set; }


    [DataType(DataType.MultilineText)]
    [Required]
    public string AboutMe { get; set; } = string.Empty;

}