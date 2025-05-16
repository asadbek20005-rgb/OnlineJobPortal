using OnlineJobPortal.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Otp;

public class OtpModel
{
    [Required]
    [StringLength(15)]
    [PhoneNumber(ErrorMessage = "Phone number must be UZB format")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public int Code { get; set; }
}
