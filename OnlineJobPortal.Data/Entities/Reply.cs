using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;

[Table("replies", Schema = "application")]
public class Reply : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("employer_id")]
    [Required]
    public Guid EmployerId { get; set; }

    [ForeignKey(nameof(EmployerId))]
    public User? Employer { get; set; }

    [Column("vacancy_id")]
    [Required]
    public int VacancyId { get; set; }

    [ForeignKey(nameof(VacancyId))]
    public Vacancy? Vacancy { get; set; }
}