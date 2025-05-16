using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("users", Schema = "application")]
public class User : Date
{
    [Key]
    [Column("id")]
    public Guid id { get; set; }

    [Column("full_name")]
    [StringLength(150)]
    public string? FullName { get; set; } = string.Empty;

    [Column("phone_number")]
    [StringLength(15)]
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;


    [Column("password_hash")]
    [StringLength(255)]
    [Required]
    public string PasswordHash { get; set; } = string.Empty;


    [Column("email")]
    [StringLength(255)]
    [EmailAddress]
    public string? Email { get; set; }

    [Column("status_id")]
    public int? StatusId { get; set; }

    [ForeignKey(nameof(StatusId))]
    public Status? Status { get; set; }


    [Column("city_id")]
    public int? CityId { get; set; }

    [ForeignKey(nameof(CityId))]
    public City? City { get; set; }


    [Column("role_id")]
    [Required]
    public int RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }

    [Column("language_id")]
    [Required]
    public int LanguageId { get; set; }

    [ForeignKey(nameof(LanguageId))]
    public Language? Language { get; set; }

    [Column("language_level_id")]
    [Required]
    public int LevelId { get; set; }

    [ForeignKey(nameof(LevelId))]
    public Level? Level { get; set; }

    public ICollection<Resume>? Resumes { get; set; }

}