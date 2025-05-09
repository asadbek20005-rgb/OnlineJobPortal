using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Bases;

public class BaseEntity : Date
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(100)]
    [Required]
    public string FullName { get; set; } = string.Empty;


    [Column("short_name")]
    [StringLength(100)]
    [Required]
    public string ShortName { get; set; } = string.Empty;


    [Column("code")]
    [StringLength(100)]
    [Required]
    public string Code { get; set; } = string.Empty;
}
