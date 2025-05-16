namespace OnlineJobPortal.Common.Dtos;

public class ResumeDto
{

    public int Id { get; set; }
    public int ProfessionId { get; set; }

    public int WorkingHourId { get; set; }

    public int CurrencyId { get; set; }

    public int TypeOfEmploymentId { get; set; }

    public int ContactId { get; set; }

    public int WorkExperianceId { get; set; }

    public int EducationId { get; set; }

    public int SkillId { get; set; }

    public Guid UserId { get; set; }

    public decimal IncomeLevelPerMonth { get; set; }
    public string Specializations { get; set; } = string.Empty;

    public string AboutMe { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;

    public bool IsHided { get; set; } = false;
}
