using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.User;

public class LoginModel
{

    [StringLength(15)]
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;


    [StringLength(255)]
    [Required]
    public string Password { get; set; } = string.Empty;
}
