using OnlineJobPortal.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.User;

public class UpdatePhoneNumberModel
{
    [StringLength(15)]
    [Required]
    [PhoneNumber(ErrorMessage = "Phone number must be UZB format")]
    public string NewPhoneNumber { get; set; } = string.Empty;


    [StringLength(255)]
    [Required]
    public string CurrentPassword { get; set; } = string.Empty;
}
