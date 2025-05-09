using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Common.Dtos;

public class DateDto
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedDate { get; set; }
}
