using OnlineJobPortal.Common.CustomAttributes;
using OnlineJobPortal.Common.Statics;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.User;

public class LoginModel
{

    [StringLength(15)]
    [Required]
    [PhoneNumber(ErrorMessage = "Phone number must be UZB format")]
    public string PhoneNumber { get; set; } = string.Empty;


    [StringLength(255)]
    [Required]
    public string Password { get; set; } = string.Empty;

    public int Role { get; set; }

}
