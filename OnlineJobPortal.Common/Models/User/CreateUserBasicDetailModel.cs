using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.User;

public class CreateUserBasicDetailModel
{
    [StringLength(150)]
    [Required]
    public string FullName { get; set; } = string.Empty;

    [StringLength(255)]
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public int CityId { get; set; }


    [Required]
    public int StatusId { get; set; }
}
