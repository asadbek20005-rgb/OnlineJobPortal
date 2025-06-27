using OnlineJobPortal.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.User;

public class RegisterModel
{
    [StringLength(15)]
    [Required]
    [PhoneNumber(ErrorMessage = "Phone number must be UZB format")]
    public string PhoneNumber { get; set; } = string.Empty;


    [StringLength(255)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [StringLength(255)]
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    public int RoleId { get; set; }

}
