using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.Models.User;

public class UpdateUserBasicDetailModel
{
    [StringLength(150)]
    [MinLength(3)]
    public string? FullName { get; set; } = string.Empty;

    [EmailAddress]
    public string? Email { get; set; }
   
    public int? CityId { get; set; }

    public int? StatusId { get; set; }

    public int? LanguageId { get; set; }

    public int? LevelId { get; set; }
    
}
