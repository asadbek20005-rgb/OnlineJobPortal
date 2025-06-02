namespace OnlineJobPortal.Common.Dtos;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public int CityId { get; set; }
}
