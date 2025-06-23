using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("vacancies", Schema = "application")]
public class Vacancy : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("profession_id")]
    [Required]
    public int ProfessionId { get; set; }
    [ForeignKey(nameof(ProfessionId))]
    public Profession? Profession { get; set; } = null!;


    [Column("company_id")]
    [Required]
    public int CompanyId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; } = null!;


    [Column("is_favourite")]
    public bool IsFavourite { get; set; } = false;


    [Column("responsibilities")]
    [DataType(DataType.MultilineText)]
    [Required]
    [MinLength(150, ErrorMessage = "About must be at least 150 letter")]
    public string Responsibilities { get; set; } = string.Empty;

    [Column("details")]
    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }

    [Column("working_hour_id")]
    [Required]
    public int WorkingHourId { get; set; } 

    [ForeignKey(nameof(WorkingHourId))]
    public WorkingHour? WorkingHour { get; set; }


    [Column("type_of_employment")]
    [Required]
    public int TypeOfEmploymentId { get; set; } 

    [ForeignKey(nameof(TypeOfEmploymentId))]

    public TypeOfEmployment? TypeOfEmployment { get; set; }
}