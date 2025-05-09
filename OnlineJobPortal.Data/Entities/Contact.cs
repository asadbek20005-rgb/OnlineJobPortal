using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("contacts", Schema = "application")]
public class Contact : Date
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("phone_number")]
    [StringLength(15)]
    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;


    [Column("email")]
    [StringLength(255)]
    [Required]
    [EmailAddress]  
    public string Email { get; set; } = string.Empty;

    [Column("details")]
    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }


}
