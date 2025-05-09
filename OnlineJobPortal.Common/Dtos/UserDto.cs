namespace OnlineJobPortal.Common.Dtos;

public class UserDto : DateDto
{
    public Guid id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int StatusId { get; set; }
    public int CityId { get; set; }
    public int RoleId { get; set; }

}
