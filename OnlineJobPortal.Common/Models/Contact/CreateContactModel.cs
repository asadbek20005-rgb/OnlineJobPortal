using OnlineJobPortal.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Contact;

public class CreateContactModel
{
    [StringLength(15)]
    [Required]
    [Phone]
    [PhoneNumber(ErrorMessage = "Phone number must be UZB format")]
    public string PhoneNumber { get; set; } = string.Empty;


    [StringLength(255)]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;


    [DataType(DataType.MultilineText)]
    public string? Details { get; set; }
}

