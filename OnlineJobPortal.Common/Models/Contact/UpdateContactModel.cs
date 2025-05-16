using OnlineJobPortal.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Contact;

public class UpdateContactModel
{
    [PhoneNumber(ErrorMessage = "Phone number must be UZB format")]
    public string? PhoneNumber { get; set; } = string.Empty;
    [EmailAddress]
    public string? Email { get; set; } = string.Empty;
    [DataType(DataType.MultilineText)]
    [MinLength(10)]
    public string? Details { get; set; }
}
