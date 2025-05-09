using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("otps", Schema = "application")]
public class Otp : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("phone_number")]
    [Required]
    [Phone]
    [StringLength(15)]

    public string PhoneNumber { get; set; } = string.Empty;

    [Column("code")]
    [Required]
    public int Code { get; set; }


    [Column("is_expired")]
    [Required]
    public bool IsExpired { get; set; }
}
