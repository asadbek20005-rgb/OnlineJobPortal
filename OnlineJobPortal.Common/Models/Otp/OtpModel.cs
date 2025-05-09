using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.Otp;

public class OtpModel
{
    [Required]
    [StringLength(15)]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public int Code { get; set; }
}
