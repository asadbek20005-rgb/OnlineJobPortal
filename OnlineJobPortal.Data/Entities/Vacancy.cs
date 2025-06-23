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
}