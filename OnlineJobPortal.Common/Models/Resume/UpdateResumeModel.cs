using OnlineJobPortal.Common.Models.Contact;
using OnlineJobPortal.Common.Models.Education;
using OnlineJobPortal.Common.Models.Skill;
using OnlineJobPortal.Common.Models.WorkExperiance;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Resume;

public class UpdateResumeModel
{
    public UpdateEducationModel? EducationModel { get; set; }
    public UpdateSkillModel? SkillModel { get; set; }
    public UpdateWorkExperianceModel? WorkExperianceModel { get; set; }
    public UpdateContactModel? ContactModel { get; set; }


    public int? ProfessionId { get; set; }
    public decimal? IncomeLevelPerMonth { get; set; }
    public int? CurrencyId { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Specializations { get; set; } = string.Empty;
    public int? WorkingHourId { get; set; }
    public int? TypeOfEmploymentId { get; set; }

    [DataType(DataType.MultilineText)]
    public string? AboutMe { get; set; } = string.Empty;

}