using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("work_experiences", Schema = "application")]
public class WorkExperience : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("company_name")]
    [StringLength(255)]
    [Required]
    public string CompanyName { get; set; } = string.Empty;


    [Column("website")]
    [DataType(DataType.Url)]
    [Required]
    public string Website { get; set; } = string.Empty;

    [Column("details")]
    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }


    [Column("job_title")]
    [StringLength(255)]
    [Required]
    public string JobTitle { get; set; } = string.Empty;


    [Column("getting_started")]
    [DataType(DataType.Date)]
    [Required]
    public DateOnly GettingStarted { get; set; } 


    [Column("ending")]
    [DataType(DataType.Date)]
    [Required]
    public DateOnly Ending { get; set; }


    [Column("responsibilities")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string Responsibilities { get; set; } = string.Empty;



}
